using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Timer
{
    public class TimerService : ITimer, ITickable
    {
        public float MaxTime { get; private set; }
        public float CurrentTime { get; private set; }

        private bool _isTimerRunning;

        public event Action OnTimerStarted;
        public event Action OnTimerFinished;
        public event Action OnTimerTicked;

        public void Initialize(float maxTime)
        {
            MaxTime = maxTime;
        }

        public void RemoveTime(float timeToRemove)
        {
            CurrentTime -= timeToRemove;
        }

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

        public void Reset()
        {
            CurrentTime = 0f;
            _isTimerRunning = false;
        }

        private void StopTimer()
        {
            _isTimerRunning = false;
            OnTimerFinished?.Invoke();
        }
    }
}