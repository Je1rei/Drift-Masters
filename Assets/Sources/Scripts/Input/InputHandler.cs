using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    private PlayerInput _input;
    private bool _isHoldingLeft;
    private bool _isHoldingRight;
    
    public event Action OnHoldLeft;
    public event Action OnHoldRight;

    private void OnEnable()
    {
        _input.Enable();

        _input.Player.MoveLeft.performed += OnMoveLeftPerformed;
        _input.Player.MoveLeft.canceled += OnMoveLeftCanceled;

        _input.Player.MoveRight.performed += OnMoveRightPerformed;
        _input.Player.MoveRight.canceled += OnMoveRightCanceled;

        _leftButton.onClick.AddListener(() => StartHoldingLeft());
        _rightButton.onClick.AddListener(() => StartHoldingRight());
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Player.MoveLeft.performed -= OnMoveLeftPerformed;
        _input.Player.MoveLeft.canceled -= OnMoveLeftCanceled;

        _input.Player.MoveRight.performed -= OnMoveRightPerformed;
        _input.Player.MoveRight.canceled -= OnMoveRightCanceled;
        
        _leftButton.onClick.RemoveAllListeners();
        _rightButton.onClick.RemoveAllListeners();
    }
    
    private void Update()
    {
        if (_isHoldingLeft)
        {
            OnHoldLeft?.Invoke();
        }

        if (_isHoldingRight)
        {
            OnHoldRight?.Invoke();
        }
    }
    
    [Inject]
    private void Construct()
    {
        _input = new PlayerInput();
    }

    private void OnMoveLeftPerformed(InputAction.CallbackContext context)
    {
        _isHoldingLeft = true;
        Debug.Log("Move Left Started Holding");
    }

    private void OnMoveLeftCanceled(InputAction.CallbackContext context)
    {
        _isHoldingLeft = false;
        Debug.Log("Move Left Stopped Holding");
    }

    private void OnMoveRightPerformed(InputAction.CallbackContext context)
    {
        _isHoldingRight = true;
        Debug.Log("Move Right Started Holding");
    }

    private void OnMoveRightCanceled(InputAction.CallbackContext context)
    {
        _isHoldingRight = false;
        Debug.Log("Move Right Stopped Holding");
    }
    
    private void StartHoldingLeft()
    {
        _isHoldingLeft = true;
    }

    private void StartHoldingRight()
    {
        _isHoldingRight = true;
    }
}