using System;

public class StartScreen : Screen
{
    public event Action PlayButtonClicked;

    public override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}