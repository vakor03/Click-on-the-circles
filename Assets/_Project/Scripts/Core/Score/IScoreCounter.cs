using System;

namespace _Project.Scripts.Core.Score
{
    public interface IScoreCounter
    {
        int CurrentScore { get; }
        void AddScore(int score);
        void Reset();
        event Action OnScoreChanged;
    }
}