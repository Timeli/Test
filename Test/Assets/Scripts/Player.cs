using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private ParticleSystem _particalSys;

    private NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.SetDestination(_finishPosition.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>())
        {
            _particalSys.Play();
        }
    }
}
