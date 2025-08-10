using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpButtonPressed;
    public event Action LeftButtonClicked;

    private readonly KeyCode _jumpButton = KeyCode.Space;
    private bool _isAvailable = true;
    
    private void Update()
    {
        if (_isAvailable == false)
        {
            return;
        }
        
        if (Input.GetKeyDown(_jumpButton))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            LeftButtonClicked?.Invoke();
        }
    }

    public void StartWorking()
    {
        _isAvailable = true;
    }

    public void StopWorking()
    {
        _isAvailable = false;
    }
}
