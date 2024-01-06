using System;

namespace _Project.Scripts
{
    public class GameOverStateObserver
    {
        public bool IsGameOver { get; private set; }
        public event Action OnGameOverStateChanged;
        
        public void SetGameOver(bool isGameOver)
        {
            IsGameOver = isGameOver;
            OnGameOverStateChanged?.Invoke();
        }
    }
}