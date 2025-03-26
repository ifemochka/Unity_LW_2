using System;
using UnityEngine;

public class Cell
{
    public event Action<int> OnValueChanged;
    public event Action<Vector2Int> OnPositionChanged;

    private int value;
    private Vector2Int position;

    public int Value
    {
        get => value;
        set
        {
            this.value = value;
            OnValueChanged?.Invoke(value);
        }
    }

    public Vector2Int Position
    {
        get => position;
        set
        {
            position = value;
            OnPositionChanged?.Invoke(position);
        }
    }

    public Cell(Vector2Int position, int initialValue)
    {
        this.Position = position;
        this.Value = initialValue;
    }
}
