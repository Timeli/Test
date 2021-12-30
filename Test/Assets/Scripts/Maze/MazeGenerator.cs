using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeGeneratorCell
{
    public MazeGeneratorCell(int x, int y)
    {
        X = x * 2;
        Z = y * 2;
    }
    public int X { get; private set; }
    public int Z { get; private set; }

    public bool WallLeft = true;
    public bool WallBottom = true;
}

public class MazeGenerator : IEnumerable
{
    private MazeGeneratorCell[,] maze;
    public MazeGeneratorCell[,] GenerateMaze(int lenX, int lenZ)
    {
        maze = new MazeGeneratorCell[lenX, lenZ];

        for (int x = 0; x < maze.GetLength(0); x++)
            for (int z = 0; z < maze.GetLength(1); z++)
                maze[x, z] = new MazeGeneratorCell(x, z);

        return maze;
    }

    public IEnumerator GetEnumerator()
    {
        return maze.GetEnumerator();
    }
}
