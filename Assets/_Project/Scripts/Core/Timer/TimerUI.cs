using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Timer
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
            _timer.OnTimerTicked += HandleTimerTicked;
        }

        private void OnDisable()
        {
            _timer.OnTimerTicked -= HandleTimerTicked;
        }

        private void HandleTimerTicked()
        {
            float timeLeft = _timer.MaxTime - _timer.CurrentTime;
            int seconds = (int)timeLeft;
            int millis = (int)(timeLeft * 100) % 100;

            timerText.text = $"{seconds}:{millis}";
        }
    }
}