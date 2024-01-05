namespace _Project.Scripts.Infrastructure.StateMachines.States
{
    public class GameOverState : IState
    {
        public void Enter()
        {
            UnityEngine.Debug.Log("Game Over");
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}