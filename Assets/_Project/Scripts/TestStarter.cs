using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class TestStarter : MonoBehaviour
    {
        private ITimer _timer;
        
        [Inject]
        private void Construct(ITimer timer)
        {
            _timer = timer;
            
            _timer.OnTimerFinished += HandleTimerFinished;
        }
        
        private void Start()
        {
            _timer.StartTimer();
        }

        private void HandleTimerFinished()
        {
            Debug.Log("Timer finished!");
        }
    }
}