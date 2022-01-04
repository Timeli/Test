using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Body : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _burstParts;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _finishPosition;

    private NavMeshAgent _navMesh;
    private readonly float _delay = 2f;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        StartCoroutine(PlayerGo());
    }

    private IEnumerator PlayerGo()
    {
        yield return new WaitForSeconds(_delay);
        _player.SetActive(true);
        _navMesh.SetDestination(_finishPosition.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>())
        {
            _particleSystem.Play();
        }
    }

    public void BreakApart()
    {
        _navMesh.Stop();
        _player.SetActive(false);
        _burstParts.SetActive(true);
    }
}
