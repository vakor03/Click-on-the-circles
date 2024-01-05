using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class TimerService : ITimer, ITickable
    {
        public float MaxTime { get; private set; } = 10f;
        public float CurrentTime { get; private set; }

        public event Action OnTimerStarted;
        public event Action OnTimerFinished;
        public event Action OnTimerTicked;

        private bool _isTimerRunning;

        public void Tick()
        {
            if (!_isTimerRunning) return;

            CurrentTime += Time.deltaTime;
            OnTimerTicked?.Invoke();

            if (CurrentTime >= MaxTime)
            {
                StopTimer();
            }
        }

        public void StartTimer()
        {
            CurrentTime = 0f;
            _isTimerRunning = true;
            OnTimerStarted?.Invoke();
        }

        public void StopTimer()
        {
            _isTimerRunning = false;
            OnTimerFinished?.Invoke();
        }
    }
}