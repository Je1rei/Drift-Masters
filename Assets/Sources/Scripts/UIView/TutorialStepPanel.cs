using System;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class TutorialStepPanel : UIPanel
    {
        [SerializeField] private Button _button;

        private AudioService _audioService;

        public event Action Clicked;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _button, Click);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
            AddButtonListener(_audioService, _button, Click);
        }

        private void Click()
        {
            Debug.Log("Clicekd");
            Clicked?.Invoke();
        }
    }
}