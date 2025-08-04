using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpButtonPressed;

    private KeyCode _jumpButton = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(_jumpButton))
        {
            JumpButtonPressed?.Invoke();
        }
    }
}
