using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _Project.Scripts
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        private InputActions _inputActions;
        public event Action<Vector2> OnClick;
        public Vector2 GetMousePosition()
        {
            return _inputActions.Player.Position.ReadValue<Vector2>();
        }

        public void Initialize()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
            _inputActions.Player.Click.performed += HandleClick;
        }

        private void HandleClick(InputAction.CallbackContext obj)
        {
            OnClick?.Invoke(_inputActions.Player.Position.ReadValue<Vector2>());
        }

        public void Dispose()
        {
            _inputActions.Player.Click.performed -= HandleClick;
            _inputActions?.Dispose();
        }
    }
    
    public interface IInputService
    {
        event Action<Vector2> OnClick;
        Vector2 GetMousePosition();
    }
}