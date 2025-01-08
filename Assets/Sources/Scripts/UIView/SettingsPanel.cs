using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UIView
{
    public class SettingsPanel : UIPanel
    {
        [SerializeField] private MainMenuPanel _mainMenu;
        [SerializeField] private AuthorizationPanel _authorizationPanel;

        [SerializeField] private Button _languageButton;
        [SerializeField] private Button _authButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _soundFXVolumeSlider;

        //private SettingsService _settingsService;

        private void OnEnable()
        {
            // _musicVolumeSlider.value = YG2.saves.Volume;
            // _settingsService = ServiceLocator.Current.Get<SettingsService>();
            // SetAudioService();

            AddButtonListener(_languageButton, OnClickLanguage);
            AddButtonListener(_backButton, OnClickBack);
            AddButtonListener(_authButton, OnClickAuth);
            //_musicVolumeSlider.onValueChanged.AddListener(_settingsService.SetVolume); // music
            //_soundFXVolumeSlider.onValueChanged.AddListener(_settingsService.SetVolume); // fxslider

            if (YG2.player.auth)
            {
                _authButton.gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _languageButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _authButton.onClick.RemoveAllListeners();
            _musicVolumeSlider.onValueChanged.RemoveAllListeners();
        }

        private void OnClickBack()
        {
            // YG2.SaveProgress();
            _mainMenu.Show();
            Hide();
        }

        private void OnClickLanguage()
        {
            // string[] languages = _settingsService.GetLanguages();
            // string currentLanguage = YG2.lang;
            //
            // int currentIndex = Array.IndexOf(languages, currentLanguage);
            // int nextIndex = (currentIndex + 1) % languages.Length;
            //
            // YG2.SwitchLanguage(languages[nextIndex]);
        }

        private void OnClickAuth()
        {
            _authorizationPanel.Show();
            Hide();
        }
    }
}