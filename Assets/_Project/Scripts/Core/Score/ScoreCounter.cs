using System;

namespace _Project.Scripts.Core.Score
{
    public class ScoreCounter : IScoreCounter
    {
        public int CurrentScore { get; private set; }

        public void AddScore(int score)
        {
            CurrentScore += score;
            OnScoreChanged?.Invoke();
        }

        public void Reset()
        {
            CurrentScore = 0;
            OnScoreChanged?.Invoke();
        }

        public event Action OnScoreChanged;
    }
}