using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public Vector3 MousePosition => _camera.ScreenToWorldPoint(Input.mousePosition);
}