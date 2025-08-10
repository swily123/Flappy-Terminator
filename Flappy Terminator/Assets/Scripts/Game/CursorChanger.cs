using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorTexture; 

    public void SetGameCursor()
    {
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void RestoreDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}