namespace _Project.Scripts.Infrastructure.StateMachines
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}