using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Body : MonoBehaviour
{
    [SerializeField] private GameObject _burstParts;
    [SerializeField] private Player _player;

    private Button _shieldButton;
    private NavMeshAgent _navMesh;
    private Vector3 _finishPos;
    
    private readonly float _delay = 2f;
   
    public bool IsActiveShild { get; private set; }
    public bool IsFinish { get; private set; }
    public bool IsDied { get; private set; }
    
    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _finishPos = FindObjectOfType<Finish>().transform.position;

        _shieldButton = FindObjectOfType<ShieldButton>().GetComponent<Button>();
        _shieldButton.onClick.AddListener(InitShield);

        StartCoroutine(PlayerGo());
    }

    
    private IEnumerator PlayerGo()
    {
        yield return new WaitForSeconds(_delay);
        _player.thisObj.SetActive(true);
        _navMesh.SetDestination(_finishPos);
    }

    public void InitShield()
    {
        StartCoroutine(ActiveShield());
        _player.InitChangeColor();
    }

    private IEnumerator ActiveShield()
    {
        IsActiveShild = true;
        yield return new WaitForSeconds(2f);
        IsActiveShild = false;
    }

    public void BreakApart()
    {
        if (IsActiveShild == false)
        {
            _navMesh.Stop();
            _player.thisObj.SetActive(false);
            _burstParts.SetActive(true);
            StartCoroutine(DisappearBody(3f));
            IsDied = true;
        }
    }

    private IEnumerator DisappearBody(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>()) 
        {
            IsFinish = true;
            StartCoroutine(DisappearBody(0));
        }
    }
}
