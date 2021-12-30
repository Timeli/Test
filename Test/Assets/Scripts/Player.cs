using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _finishPosition;
    private NavMeshAgent _navMesh;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _navMesh.SetDestination(_finishPosition.position);
    }

    private void FixedUpdate()
    {
        
    }
}
