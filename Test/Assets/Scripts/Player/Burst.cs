using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burst : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float delay = 0.05f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator AddBurst(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        rigidbody.AddForce(Vector3.up * 100, ForceMode.Impulse);
    }


    private void OnEnable()
    {
        StartCoroutine(AddBurst(delay));
    }
}
