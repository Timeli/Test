using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _obj;
    private Cell[,] _cells;
    private readonly int _height = 11;
    private readonly int _width = 16;
    private int posX = 0;
    private int posZ = 0;
    int cntIsActive = 0;
    private void Start()
    {
        _cells = new Cell[_height, _width];
        CarcassGenerate();
        StartCoroutine(MazeGenerate());
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

    private IEnumerator MazeGenerate()
    {
        List<Cell> cellList = new List<Cell>();
        Stack<Cell> cellStack = new Stack<Cell>();
        
        _cells[0, 0].IsVisited = true;

        while (true)
        {
            // ищу непосещ соседей текущ клетки и помещ в лист
            if (posX - 1 >= 0 && _cells[posZ, posX - 1].IsVisited == false)
                cellList.Add(_cells[posZ, posX - 1]);
            if (posX + 1 < _width && _cells[posZ, posX + 1].IsVisited == false)
                cellList.Add(_cells[posZ, posX + 1]);
            if (posZ - 1 >= 0 && _cells[posZ - 1, posX].IsVisited == false)
                cellList.Add(_cells[posZ - 1, posX]);
            if (posZ + 1 < _height && _cells[posZ + 1, posX].IsVisited == false)
                cellList.Add(_cells[posZ + 1, posX]);

            // выбир случ клетку из листа и иду в нее
            // остальные помещ в стек
            // лист чищу
            //print("List Count: " + cellList.Count);
            if (cellList.Count > 0)
            {
                int index = Random.Range(0, cellList.Count);
                //print("Random Index: " + index);
                Cell cell = cellList[index];
                OpenDoor(posX, posZ, cell);
                cellList.RemoveAt(index);
                for (int i = 0; i < cellList.Count; i++)
                {
                    if (cellStack.Contains(cellList[i]) == false)
                        cellStack.Push(cellList[i]);
                }

                cellList.Clear();
                
                print("Active Cell: " + cntIsActive);
                posX = cell.X;
                posZ = cell.Z;
            }
            else
            {
                if (cellStack.Count > 0)
                {
                    Cell cell = cellStack.Pop();
                    posX = cell.X;
                    posZ = cell.Z;
                }
                else
                {
                    print("Break");
                    break;
                }
            }
            StartCoroutine(Move(new Vector3(posX, 1.1f, posZ)));
            //print("Current Pos: " + " X: " + posX + " Z: " + posZ);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OpenDoor(int currentX, int currentZ, Cell next)
    {
        Cell prev = _cells[currentZ, currentX];
        if (prev.X < next.X)
        {
            prev.LeftWall.SetActive(false);
            prev.IsVisited = true;
        }
        else if (prev.Z < next.Z)
        {
            prev.BottomWall.SetActive(false);
            prev.IsVisited = true;
        }
        else if (prev.X > next.X)
        {
            next.LeftWall.SetActive(false);
            next.IsVisited = true;
        }
        else if (prev.Z > next.Z)
        {
            next.BottomWall.SetActive(false);
            next.IsVisited = true;
        }
        cntIsActive++;


    }

    private IEnumerator Move(Vector3 vector)
    {
        if ((_obj.transform.position - vector).magnitude > 1.1)
            _obj.transform.position = vector;

        for (int i = 0; i < 5; i++)
        {
            _obj.transform.position = Vector3.MoveTowards(_obj.transform.position, vector, 1 / 2.5f);
            yield return null;
        }
    }

  
       
}
