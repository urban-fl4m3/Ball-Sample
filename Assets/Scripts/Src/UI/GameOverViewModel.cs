using System;

namespace Src.UI
{
    public readonly struct GameOverViewModel
    {
        public readonly bool IsWon;
        public readonly Action RestartPressed;

        public GameOverViewModel(bool isWon, Action restartPressed)
        {
            IsWon = isWon;
            RestartPressed = restartPressed;
        }
    }
}