using System;
using _Project.Scripts.Score;
using _Project.Scripts.Timer;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class TestStarter : MonoBehaviour
    {
        private ITimer _timer;
        private IScoreCounterService _scoreCounterService;
        
        [Inject]
        private void Construct(ITimer timer, IScoreCounterService scoreCounterService)
        {
            _timer = timer;
            _scoreCounterService = scoreCounterService;
            
            _timer.OnTimerFinished += HandleTimerFinished;
        }
        
        private void Start()
        {
            _timer.StartTimer();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _scoreCounterService.AddScore(10);
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                _scoreCounterService.ResetScore();
            }
        }

        private void HandleTimerFinished()
        {
            Debug.Log("Timer finished!");
        }
    }
}