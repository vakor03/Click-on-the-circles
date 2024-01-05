using System;

namespace _Project.Scripts.Score
{
    public interface IScoreCounterService
    {
        int CurrentScore { get; }
        void AddScore(int score);
        void ResetScore();
        event Action OnScoreChanged;
    }
}