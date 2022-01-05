using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Body : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _burstParts;
    [SerializeField] private ParticleSystem _particleSystem;
    
    private NavMeshAgent _navMesh;
    private readonly float _delay = 2f;

    private Transform _finishPosition;
    private bool _isActiveShield;

    public event Action ReachedFinish;
    public event Action Died;

    private void Start()
    {
        _finishPosition = FindObjectOfType<Finish>().transform;
        _navMesh = GetComponent<NavMeshAgent>();
        StartCoroutine(PlayerGo());
    }

    private IEnumerator PlayerGo()
    {
        yield return new WaitForSeconds(_delay);
        _player.SetActive(true);
        _navMesh.SetDestination(_finishPosition.position);
    }

    public void InitShield()
    {
        StartCoroutine(ActiveShield());
        _player.GetComponent<Player>().InitChangeColor();
    }

    private IEnumerator ActiveShield()
    {
        _isActiveShield = true;
        yield return new WaitForSeconds(2f);
        _isActiveShield = false;
    }

    public void BreakApart()
    {
        if (_isActiveShield == false)
        {
            _navMesh.Stop();
            _player.SetActive(false);
            _burstParts.SetActive(true);
            Died?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>())
        {
            ReachedFinish?.Invoke();
        }
    }
}
