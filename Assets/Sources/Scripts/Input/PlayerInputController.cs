using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _input;
    private float _pozititiv = 1;
    private float _negativ = -1;
    public event Action<float> Moved;

    private void OnEnable()
    {
        _input.Enable();

        _input.Player.MoveLeft.performed += OnMoveLeftPressed;
        _input.Player.MoveRight.performed += OnMoveRightPressed;
        
        _input.Player.Move.performed += OnMoveAxis;
    }

    private void OnDisable()
    {
        _input.Disable();
        
        _input.Player.MoveLeft.performed -= OnMoveLeftPressed;
        _input.Player.MoveRight.performed -= OnMoveRightPressed;
        
        _input.Player.Move.performed -= OnMoveAxis;

    }

    private void Awake()
    {
        _input ??= new PlayerInput();
    }

    [Inject]
    private void Construct()
    {
        _input = new PlayerInput();
    }

    private void OnMoveLeftPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Move Left Pressed");
        Moved?.Invoke(_negativ);
    }

    private void OnMoveRightPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Move Right Pressed");
        Moved?.Invoke(_pozititiv);
    }

    private void OnMoveAxis(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>());
    }
}