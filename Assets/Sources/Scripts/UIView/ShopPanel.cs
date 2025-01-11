using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class ShopPanel : UIPanel
    {
        [SerializeField] private Button _backButton;

        private AudioService _audioService;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _backButton, OnClickBack);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        private void OnClickBack()
        {
            Hide();
        }
    }
}