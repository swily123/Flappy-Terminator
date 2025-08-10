using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpButtonPressed;
    public event Action LeftButtonClicked;

    private KeyCode _jumpButton = KeyCode.Space;
    private bool _isAviable = true;
    
    private void Update()
    {
        if (_isAviable == false)
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
        _isAviable = true;
    }

    public void StopWorking()
    {
        _isAviable = false;
    }
}
