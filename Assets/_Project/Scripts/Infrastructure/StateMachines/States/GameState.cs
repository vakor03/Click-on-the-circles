using _Project.Scripts.Core.Timer;

namespace _Project.Scripts.Infrastructure.StateMachines.States
{
    public class GameState : IState
    {
        private ITimer _timer;
        private GameStateMachine _gameStateMachine;

        public GameState(ITimer timer, 
            GameStateMachine gameStateMachine)
        {
            _timer = timer;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _timer.OnTimerFinished += HandleTimerFinished;
            _timer.StartTimer();
        }

        private void HandleTimerFinished()
        {
           _gameStateMachine.Enter<GameOverState>(); 
        }

        public void Exit()
        {
            _timer.Reset();
            _timer.OnTimerFinished -= HandleTimerFinished;
        }
    }
}