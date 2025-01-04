using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _input;

    private void OnEnable()
    {
        _input.Enable();
        // сюда добавить обработку
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    [Inject]
    private void Construct()
    {
        _input = new PlayerInput();
    }

    private void OnMoveLeftPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Move Left Pressed");
    }

    private void OnMoveRightPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Move Right Pressed");
    }
}