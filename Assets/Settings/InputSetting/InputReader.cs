using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject,Controls.IPlayerActions

{
    public event Action<Vector2> MovementEvent;
    public event Action AttackEvent;
    public event Action MouseSpecialEvent;
    public event Action DashEvent;


    public event Action JumpEvent;

    private Controls _controls;
    public Vector2 Movement { get; private set; }


    private void OnEnable()
    {
        if (_controls == null)
            _controls = new Controls();

        _controls.Player.Enable();
        _controls.Player.SetCallbacks(this);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (!context.canceled)
            Movement = context.ReadValue<Vector2>();
        else
        {
            Movement = Vector2.zero;
        }
            MovementEvent?.Invoke(Movement);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
            JumpEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            AttackEvent?.Invoke();
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        if (context.performed)
            MouseSpecialEvent?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.performed)
            DashEvent?.Invoke();
    }
}
