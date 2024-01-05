using System;

namespace _Project.Scripts.Timer
{
    public interface ITimer
    {
        float MaxTime { get; }
        float CurrentTime { get; }
        void StartTimer();
        void StopTimer();
        event Action OnTimerStarted;
        event Action OnTimerFinished;
        event Action OnTimerTicked;
    }
}