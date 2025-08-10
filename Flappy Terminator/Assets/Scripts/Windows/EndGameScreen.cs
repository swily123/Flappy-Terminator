using System;

namespace Windows
{
    public class EndGameScreen : Screen
    {
        public event Action RestartButtonClicked;

        protected override void OnButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }
    }
}