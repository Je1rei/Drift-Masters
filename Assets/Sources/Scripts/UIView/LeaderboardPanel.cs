using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class LeaderboardPanel : UIPanel
    {
        [SerializeField] private MainMenuPanel _mainMenu;
        [SerializeField] private Button _backButton;

        private AudioService _audioService;
        
        private void OnEnable()
        {
            //SetAudioService();
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
            _mainMenu.CarPanel.ToggleView();
            Hide();
        }
    }
}