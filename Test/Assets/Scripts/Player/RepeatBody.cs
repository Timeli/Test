using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RepeatBody : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private Vector3 _finishPos;
    private NavMeshAgent _navMesh;

    public bool IsFinish { get; private set; }

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _finishPos = FindObjectOfType<Finish>().transform.position;

        _navMesh.SetDestination(_finishPos);
        _particleSystem.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>())
        {
            _particleSystem.Stop();
            IsFinish = true;
            gameObject.SetActive(false);
        }
    }
}
