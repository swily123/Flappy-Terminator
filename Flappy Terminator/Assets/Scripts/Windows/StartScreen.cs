using System;

namespace Windows
{
    public class StartScreen : Screen
    {
        public event Action PlayButtonClicked;

        protected override void OnButtonClick()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}