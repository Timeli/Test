using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public GameObject cellPrefab;
    private float offsetX = -9.75f;
    private float offsetZ = -4.75f;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GenerateMaze(10, 7);

        foreach (var item in maze)
        {
            Instantiate(cellPrefab, new Vector3(item.X + offsetX, 0, item.Z + offsetZ),
                                                                  Quaternion.identity);
        }
    }
}
