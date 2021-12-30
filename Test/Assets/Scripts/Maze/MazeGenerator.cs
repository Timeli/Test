using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGeneratorCell
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public MazeGeneratorCell(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool WallLeft = true;
    public bool WallBottom = true;
}

public class MazeGenerator 
{
    public int Width = 23;
    public int Height = 15;

    public MazeGeneratorCell[,] GenerateMaze()
    {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell(x, y);
            }
        }
        return maze;
    }
}
