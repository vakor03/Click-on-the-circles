using System;

namespace _Project.Scripts.Core.Score
{
    public class ScoreCounter : IScoreCounter
    {
        public int CurrentScore { get; private set; }

        public event Action OnScoreChanged;

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
    }
}