using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject,Controls.IPlayerActions

{
    public event Action<Vector2> MovementEvent;

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
        Movement = context.ReadValue<Vector2>();
        MovementEvent?.Invoke(Movement);
    }

}
