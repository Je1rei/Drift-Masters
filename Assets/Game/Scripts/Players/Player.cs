using System;
using Infrastructure;
using Inputs;
using Levels;
using Services;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Drifter _drifter;
        [SerializeField] private AnimateWheels _animateWheels;

        private int _totalItems;
        private int _requiredItems;
        private int _collectedRequiredItems;
        private int _collectedAllItems;

        private bool _isGameOver;

        private AudioService _audioService;
        private InputPause _inputPause;
        private WalletGamePlay _wallet;

        private StartPoint _startPosition;

        public event Action Destroyed;
        public event Action<int> Wins;
        public event Action PreparedWins;

        public void Construct(TutorialService tutorialService, Car car, int countRequiredItems, int countAllItems,
            AudioService audioService,
            WalletGamePlay wallet,
            InputPause inputPause, StartPoint startPosition)
        {
            _audioService = audioService;
            _wallet = wallet;
            _inputPause = inputPause;
            _startPosition = startPosition;

            _totalItems = countAllItems;
            _requiredItems = countRequiredItems;
            _collectedRequiredItems = 0;
            ResetProgress();

            _drifter.Construct(tutorialService, _inputPause, car.DriftConfig);
            _animateWheels.Construct(car);
            
            ResetPosition();
        }

        public void Lose()
        {
            if (_isGameOver)
            {
                return;
            }

            _isGameOver = true;

            _inputPause.DeactivateInput();
            _audioService.PlayDestroyedSound();

            if (_collectedRequiredItems >= _requiredItems)
            {
                _inputPause.DeactivateInput();
                Wins?.Invoke(_wallet.Value);
            }
            else
            {
                _inputPause.DeactivateInput();
                Destroyed?.Invoke();
            }
        }

        public void Win()
        {
            if (_collectedRequiredItems == _requiredItems)
            {
                PreparedWins?.Invoke();
            }

            if (_collectedRequiredItems >= _requiredItems && _collectedAllItems == _totalItems)
            {
                _inputPause.DeactivateInput();
                Wins?.Invoke(_wallet.Value);
            }
        }

        public void Continue()
        {
            ResetPosition();
            ResetProgress();

            _drifter.SetupContinue();
            _inputPause.ActivateInput();
        }

        public void Increase(int amount, bool isRequiredItem)
        {
            _audioService.PlayOneShot();

            if (isRequiredItem)
            {
                _collectedRequiredItems++;
            }

            _collectedAllItems++;
            _wallet.Increase(amount);
        }

        private void ResetPosition()
        {
            transform.position = _startPosition.transform.position;
            transform.rotation = Quaternion.identity;
        }

        private void ResetProgress()
        {
            _collectedRequiredItems = 0;
            _collectedAllItems = 0;
            _isGameOver = false;
        }
    }
}