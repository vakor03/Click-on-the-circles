using System;
using _Project.Scripts.Infrastructure.StateMachines;
using _Project.Scripts.Infrastructure.StateMachines.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(Button))]
    public class SwitchStateButton : MonoBehaviour
    {
        private Button _button;

        [SerializeField] private NextState nextState;

        private GameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleClick);
        }

        private void HandleClick()
        {
            switch (nextState)
            {
                case NextState.MainMenu:
                    _gameStateMachine.Enter<MainMenuState>();
                    break;
                case NextState.LoadGame:
                    _gameStateMachine.Enter<LoadGameState>();
                    break;
                case NextState.GameOver:
                    _gameStateMachine.Enter<GameOverState>();
                    break;
                case NextState.Game:
                    _gameStateMachine.Enter<GameState>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private enum NextState
        {
            None = 0,
            MainMenu = 1,
            LoadGame = 2,
            GameOver = 3,
            Game = 4
        }
    }
}