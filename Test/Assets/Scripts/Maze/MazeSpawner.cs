using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject cellPrefab;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
    }
}
