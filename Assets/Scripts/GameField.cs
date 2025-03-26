using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameField : MonoBehaviour
{
    public int size = 4;
    public int width = 4;
    public int height = 4;
    private List<Cell> cells = new List<Cell>();
    public GameObject cellPrefab;
    private int score = 0;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                cells.Add(new Cell(new Vector2Int(x, y), 0));
            }
        }
        CreateCell();
        CreateCell();
    }

    public void Move(Vector2 direction)
    {
        bool moved = false;

        if (direction == Vector2.up)
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = size - 1; y >= 0; y--)
                {
                    MoveCell(x, y, x, y - 1, ref moved);
                }
            }
        }

        if (moved)
        {
            CreateCell();
            UpdateScore();
        }
    }

    private void MoveCell(int fromX, int fromY, int toX, int toY, ref bool moved)
    {
        Cell fromCell = cells[fromY * size + fromX];
        Cell toCell = cells[toY * size + toX];

        if (fromCell.Value > 0 && toCell.Value == 0)
        {
            toCell.Value = fromCell.Value;
            fromCell.Value = 0;
            moved = true;
        }
    }


    public Vector2Int GetEmptyPosition()
    {
        List<Vector2Int> emptyPositions = new List<Vector2Int>();

        foreach (var cell in cells)
        {
            if (cell.Value == 0)
                emptyPositions.Add(cell.Position);
        }

        if (emptyPositions.Count > 0)
        {
            return emptyPositions[Random.Range(0, emptyPositions.Count)];
        }

        return new Vector2Int(-1, -1);
    }

    public void CreateCell()
    {
        Vector2Int position = GetEmptyPosition();
        if (position.x == -1) 
        { 
            return; 
        }

        int value;
        int prob = Random.Range(0, 10);
        if (prob <= 9)
        {
            value = 1;
        }
        else
        {
            value = 2;
        }
        Cell newCell = new Cell(position, value);
        cells.Add(newCell);

        GameObject cellViewObject = Instantiate(cellPrefab);
        CellView cellView = cellViewObject.GetComponent<CellView>();
        cellView.Init(newCell);
    }

    private void UpdateScore()
    {
        score = 0;
        foreach (var cell in cells)
        {
            score += cell.Value;
        }
        Debug.Log($"Current score: {score}");
    }

    public void CheckGameOver()
    {
        if (!CanMakeMove())
        {
            Debug.Log("Game over");
        }
    }

    private bool CanMakeMove()
    {
        return true;
    }

}
