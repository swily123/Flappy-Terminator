using System;

public class EndGameScreen : Screen
{
    public event Action RestartButtonClicked;

    public override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}