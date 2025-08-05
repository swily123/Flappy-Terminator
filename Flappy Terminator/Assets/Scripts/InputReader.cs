using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorTexture;

    public event Action JumpButtonPressed;
    public event Action LeftButtonClicked;

    private KeyCode _jumpButton = KeyCode.Space;

    private void Start()
    {
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LeftButtonClicked?.Invoke();
        }
    }
}
