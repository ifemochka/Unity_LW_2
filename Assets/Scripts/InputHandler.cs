using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private GameField gameField;

    private void Awake()
    {
        gameField = FindObjectOfType<GameField>();
    }

    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            HandleMove(Vector2.up);
        }
        else if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            HandleMove(Vector2.down);
        }
        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            HandleMove(Vector2.left);
        }
        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            HandleMove(Vector2.right);
        }
    }

    private void HandleMove(Vector2 direction)
    {
        Debug.Log($"Move: {direction}");
        gameField.Move(direction); 
    }
}
