using System;

namespace _Project.Scripts.Score
{
    public class ScoreCounterService : IScoreCounterService
    {
        public int CurrentScore { get; private set; }

        public void AddScore(int score)
        {
            CurrentScore += score;
            OnScoreChanged?.Invoke();
        }

        public void ResetScore()
        {
            CurrentScore = 0;
            OnScoreChanged?.Invoke();
        }

        public event Action OnScoreChanged;
    }
}