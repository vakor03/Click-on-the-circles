// using System;
// using _Project.Scripts.Core.Score;
// using _Project.Scripts.Core.Timer;
// using UnityEngine;
// using Zenject;
//
// namespace _Project.Scripts
// {
//     public class TestStarter : MonoBehaviour
//     {
//         private ITimer _timer;
//         private IScoreCounter _scoreCounter;
//         
//         [Inject]
//         private void Construct(ITimer timer, IScoreCounter scoreCounter)
//         {
//             _timer = timer;
//             _scoreCounter = scoreCounter;
//             
//             _timer.OnTimerFinished += HandleTimerFinished;
//         }
//         
//         private void Start()
//         {
//             _timer.StartTimer();
//         }
//
//         private void Update()
//         {
//             if (Input.GetKeyDown(KeyCode.Space))
//             {
//                 _scoreCounter.AddScore(10);
//             }
//             
//             if (Input.GetKeyDown(KeyCode.R))
//             {
//                 _scoreCounter.Reset();
//             }
//         }
//
//         private void HandleTimerFinished()
//         {
//             Debug.Log("Timer finished!");
//         }
//     }
// }