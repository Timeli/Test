using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _finishPosition;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _redZonePrefab;

    private NavMeshAgent _navMesh;
    private bool _isFinish;

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        StartCoroutine(PlayerGo());
    }

    private IEnumerator PlayerGo()
    {
        yield return new WaitForSeconds(0.5f);
        _navMesh.SetDestination(_finishPosition.position);
        _navMesh.isStopped = false;
        StartCoroutine(RedZoneSpawn(1f));
    }

    private IEnumerator RedZoneSpawn(float delay)
    {
        var duration = new WaitForSeconds(delay);
        yield return duration;
        while (_isFinish == false)
        {
            Instantiate(_redZonePrefab, GetCurrentPos(), Quaternion.identity);
            yield return duration;
        }
    }

    private Vector3 GetCurrentPos()
    {
        return new Vector3(_spawnPoint.position.x,
                           _spawnPoint.position.y,
                           _spawnPoint.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>())
        {
            _isFinish = true;
            gameObject.SetActive(false);
        }
    }


}
