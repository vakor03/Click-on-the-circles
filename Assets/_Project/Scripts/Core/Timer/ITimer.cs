using System;

namespace _Project.Scripts.Core.Timer
{
    public interface ITimer
    {
        float MaxTime { get; }
        float CurrentTime { get; }
        void StartTimer();
        void StopTimer();
        void Reset();
        void Initialize(float maxTime);
        event Action OnTimerStarted;
        event Action OnTimerFinished;
        event Action OnTimerTicked;
    }
}