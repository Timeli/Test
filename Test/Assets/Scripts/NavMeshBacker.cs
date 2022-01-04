using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBacker : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;

    private void Start()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        _navMeshSurface.BuildNavMesh();
        
    }
}
