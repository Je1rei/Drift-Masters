using Services;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UIView
{
    public class AuthorizationPanel : UIPanel
    {
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private Button _agreeButton;
        [SerializeField] private Button _backButton;

        private AudioService _audioService;
        
        private void OnEnable()
        {
            //SetAudioService();

            AddButtonListener(_audioService, _agreeButton, OnClickAgree);
            AddButtonListener(_audioService, _backButton, OnClickBack);
        }

        private void OnDisable()
        {
            _agreeButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService)
        {
            _audioService = audioService;
        }

        private void OnClickAgree()
        {
            YG2.OpenAuthDialog();
            _settingsPanel.Show();
            Hide();
        }

        private void OnClickBack()
        {
            _settingsPanel.Show();
            Hide();
        }
    }
}