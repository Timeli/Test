using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;

    private Cell[,] _cells;
    Cell currCell = null;
    Cell nextCell = null;

    private readonly int _height = 11;
    private readonly int _width = 16;

    private void Start()
    {
        _cells = new Cell[_height, _width];
        CarcassGenerate();
        MazeGenerate();
    }

    private void CarcassGenerate()
    {
        for (int z = 0; z < _height; z++)
        {
            for (int x = 0; x < _width; x++)
            {
                var temp = Instantiate(_cellPrefab, new Vector3(x, 0.1f, z), Quaternion.identity);
                _cells[z, x] = temp.GetComponent<Cell>();
                _cells[z, x].X = x;
                _cells[z, x].Z = z;
            }
        }
    }

    private void MazeGenerate()
    {
        List<Cell> cellList = new List<Cell>();
        Stack<Cell> cellStack = new Stack<Cell>();
        currCell = _cells[0, 0];

        for (int i = 0; i < 500; i++)
        {
            // нахожу все непосещенные ячейки вокруг текущей
            GetAllUnvisitedNeighbor(cellList);

            // если непосещ нет - беру из стека 
            if (cellList.Count == 0)
            {
                currCell = cellStack.Pop();
                continue;
            }

            // выбираю случайную из непосещенных и очищ лист
            nextCell = cellList[Random.Range(0, cellList.Count)];
            cellList.Clear();

            // открываю проход от текущей к случайной.
            // обе ячейки помечаются посещенными.
            // случайн станов текущ
            MakeRoad();

            // добавляю случайную в стек
            cellStack.Push(currCell);
        }
    }
    
    private void MakeRoad()
    {
        if (currCell.X < nextCell.X)
            currCell.LeftWall.SetActive(false);
        else if (currCell.Z < nextCell.Z)
            currCell.BottomWall.SetActive(false);
        else if (currCell.X > nextCell.X)
            nextCell.LeftWall.SetActive(false);
        else if (currCell.Z > nextCell.Z)
            nextCell.BottomWall.SetActive(false);
            
        currCell.IsVisited = true;
        nextCell.IsVisited = true;
        
        currCell = nextCell;
    }
    
    private void GetAllUnvisitedNeighbor(List<Cell> listCell)
    {
        if (currCell.X - 1 >= 0 && _cells[currCell.Z, currCell.X - 1].IsVisited == false)
            listCell.Add(_cells[currCell.Z, currCell.X - 1]);
        if (currCell.X + 1 < _width && _cells[currCell.Z, currCell.X + 1].IsVisited == false)
            listCell.Add(_cells[currCell.Z, currCell.X + 1]);
        if (currCell.Z - 1 >= 0 && _cells[currCell.Z - 1, currCell.X].IsVisited == false)
            listCell.Add(_cells[currCell.Z - 1, currCell.X]);
        if (currCell.Z + 1 < _height && _cells[currCell.Z + 1, currCell.X].IsVisited == false)
            listCell.Add(_cells[currCell.Z + 1, currCell.X]);
    }
}
