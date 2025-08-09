using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Texture2D _cursorTexture;

    public event Action JumpButtonPressed;
    public event Action LeftButtonClicked;

    private KeyCode _jumpButton = KeyCode.Space;
    public Vector3 MousePosition => _camera.ScreenToWorldPoint(Input.mousePosition);

    private bool _isAvibale = false;
    
    private void Update()
    {
        if (_isAvibale)
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
    
    public void SetGameCursor()
    {
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void RestoreDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void StartWorking()
    {
        _isAvibale = true;
    }

    public void StopWorking()
    {
        _isAvibale = false;
    }
}
