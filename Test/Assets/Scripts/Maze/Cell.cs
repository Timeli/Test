using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour 
{
    public int X { get; set; }
    public int Z { get; set; }

    public GameObject LeftWall;
    public GameObject BottomWall;

    public bool IsVisited;
}
