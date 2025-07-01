using Extensions;
using UnityEngine.InputSystem;

namespace GameMechanics.Input
{
    public class PlayerInputManager : Monosingleton<PlayerInputManager>
    {
        private PlayerInputActions _playerInputActions;

        protected override void Awake()
        {
            base.Awake();
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _playerInputActions.Player.Shoot.started += OnShoot;
        }

        private void OnShoot(InputAction.CallbackContext obj)
        {
            PlayerInputEvents.Instance.onShoot?.Invoke();
        }
        
        private void UnSubscribeEvents()
        {
            _playerInputActions.Player.Shoot.started -= OnShoot;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        
    }
}