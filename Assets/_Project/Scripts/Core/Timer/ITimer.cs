using System;

namespace _Project.Scripts.Core.Timer
{
    public interface ITimer
    {
        float MaxTime { get; }
        float CurrentTime { get; }
        void StartTimer();
        void Reset();
        void Initialize(float maxTime);
        void RemoveTime(float timeToRemove);
        event Action OnTimerStarted;
        event Action OnTimerFinished;
        event Action OnTimerTicked;
    }
}