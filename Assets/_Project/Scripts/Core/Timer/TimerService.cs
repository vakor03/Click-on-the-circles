using System;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Timer
{
    public class TimerService : ITimer, ITickable
    {
        public float MaxTime { get; private set; }
        public float CurrentTime { get; private set; }

        public void Initialize(float maxTime)
        {
            MaxTime = maxTime;
        }

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
            Debug.Log("Timer started");
        }

        private void StopTimer()
        {
            _isTimerRunning = false;
            OnTimerFinished?.Invoke();
        }

        public void Reset()
        {
            CurrentTime = 0f;
            _isTimerRunning = false;
        }
    }
}