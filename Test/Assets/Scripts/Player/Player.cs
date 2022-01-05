using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private Material _commonMat;
    [SerializeField] private Material _defenceMat;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void InitChangeColor()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        _renderer.material = _defenceMat;
        yield return new WaitForSeconds(2f);
        _renderer.material = _commonMat;
    }
}