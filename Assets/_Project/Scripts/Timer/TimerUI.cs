using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Timer
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        
        private ITimer _timer;

        [Inject]
        private void Construct(ITimer timer)
        {
            _timer = timer;
        }
        
        private void OnEnable()
        {
            _timer.OnTimerStarted += HandleTimerStarted;
            _timer.OnTimerFinished += HandleTimerFinished;
            _timer.OnTimerTicked += HandleTimerTicked;
        }

        private void HandleTimerTicked()
        {
            float timeLeft = _timer.MaxTime - _timer.CurrentTime;
            int seconds = (int) timeLeft; 
            int millis = (int) (timeLeft * 100) % 100;
            
            timerText.text = $"{seconds}:{millis}";
        }

        private void HandleTimerFinished()
        {
            // no-op
        }

        private void HandleTimerStarted()
        {
            // no-op
        }

        private void OnDisable()
        {
            _timer.OnTimerStarted -= HandleTimerStarted;
            _timer.OnTimerFinished -= HandleTimerFinished;
            _timer.OnTimerTicked -= HandleTimerTicked;
        }
    }
}