using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inputs
{
    public class InputHandler : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private readonly float _minValue = -1f;
        private readonly float _maxValue = 1f;

        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;

        [SerializeField] private float _deadZone = 0.01f;
        [SerializeField] private float _smoothTime = 0.1f;

        private bool _isLeftPressed;
        private bool _isRightPressed;

        private float _steeringValue = 0f;
        private float _steeringVelocity = 0f;

        public event Action<float> Moving;

        private void OnEnable()
        {
            SetupButtonTriggers(_leftButton,
                onPointerDown: () => _isLeftPressed = true,
                onPointerUp: () => _isLeftPressed = false);

            SetupButtonTriggers(_rightButton,
                onPointerDown: () => _isRightPressed = true,
                onPointerUp: () => _isRightPressed = false);
        }

        private void Update()
        {
            UpdateSteeringValue();
            ResetValue();

            if (Mathf.Abs(_steeringValue) > _deadZone)
            {
                Moving?.Invoke(_steeringValue);
                //Debug.Log($"Steering Value: {_steeringValue}");
            }
        }

        private void SetupButtonTriggers(Button button, Action onPointerDown, Action onPointerUp)
        {
            var trigger = button.gameObject.AddComponent<EventTrigger>();

            AddEventTrigger(trigger, EventTriggerType.PointerDown, eventData => onPointerDown());
            AddEventTrigger(trigger, EventTriggerType.PointerUp, eventData => onPointerUp());
        }

        private void AddEventTrigger(EventTrigger trigger, EventTriggerType eventType, Action<BaseEventData> callback)
        {
            var entry = new EventTrigger.Entry { eventID = eventType };
            entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
            trigger.triggers.Add(entry);
        }

        private void UpdateSteeringValue()
        {
            float horizontalInput = Input.GetAxis(Horizontal);

            if (horizontalInput != 0f)
            {
                _steeringValue = horizontalInput;
            }
            else if (_isLeftPressed == _isRightPressed)
            {
                _steeringValue = Mathf.SmoothDamp(_steeringValue, 0f, ref _steeringVelocity, _smoothTime);
            }
            else
            {
                float target = _isLeftPressed ? _minValue : _maxValue;
                _steeringValue = Mathf.SmoothDamp(_steeringValue, target, ref _steeringVelocity, _smoothTime);

                if (Mathf.Abs(_steeringValue - target) < _deadZone)
                {
                    _steeringValue = target;
                    _steeringVelocity = 0f;
                }
            }
        }

        private void ResetValue()
        {
            if (_isLeftPressed == false && _isRightPressed == false && Mathf.Abs(_steeringValue) < _deadZone)
            {
                _steeringValue = 0f;
                _steeringVelocity = 0f;
            }
        }
    }
}