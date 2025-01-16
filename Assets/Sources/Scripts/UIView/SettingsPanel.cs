using System;
using Services;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UIView
{
    public class SettingsPanel : UIPanel
    {
        [SerializeField] private MainMenuPanel _mainMenu;
        [SerializeField] private AuthorizationPanel _authorizationPanel;
        
        [SerializeField] private Image _languageFlag;
        [SerializeField] private Button _languageButton;
        [SerializeField] private Button _authButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _soundFXVolumeSlider;

        private AudioService _audioService;
        private SettingsService _settingsService;

        private void OnEnable()
        {
            _musicVolumeSlider.value = YG2.saves.MusicVolume;
            _soundFXVolumeSlider.value = YG2.saves.SoundFxVolume;

            AddButtonListener(_audioService, _languageButton, OnClickLanguage);
            AddButtonListener(_audioService, _backButton, OnClickBack);
            AddButtonListener(_audioService, _authButton, OnClickAuth);

            _musicVolumeSlider.onValueChanged.AddListener(_audioService.SetMusicVolume);
            _soundFXVolumeSlider.onValueChanged.AddListener(_audioService.SetSFXVolume);

            if (YG2.player.auth)
            {
                _authButton.gameObject.SetActive(false);
            }
            
            Sprite newFlag = _settingsService.GetFlagForLanguage(YG2.lang);
            
            if (newFlag != null)
            {
                _languageFlag.sprite = newFlag;
            }
        }

        private void OnDisable()
        {
            _languageButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
            _authButton.onClick.RemoveAllListeners();

            _musicVolumeSlider.onValueChanged.RemoveAllListeners();
            _soundFXVolumeSlider.onValueChanged.RemoveAllListeners();
        }

        public void Construct(AudioService audioService, SettingsService settingsService)
        {
            _audioService = audioService;
            _settingsService = settingsService;
            
            _authorizationPanel.Construct(audioService);
        }

        private void OnClickBack()
        {
            YG2.SaveProgress();
            _mainMenu.CarPanel.ToggleView();
            Hide();
        }

        private void OnClickLanguage()
        {
            string[] languages = _settingsService.GetLanguages();
            string currentLanguage = YG2.lang;

            int currentIndex = Array.IndexOf(languages, currentLanguage);
            int nextIndex = (currentIndex + 1) % languages.Length;
            
            string nextLanguage = languages[nextIndex];
            Sprite newFlag = _settingsService.GetFlagForLanguage(nextLanguage);
            
            if (newFlag != null)
            {
                _languageFlag.sprite = newFlag;
            }
            
            YG2.SwitchLanguage(nextLanguage);
        }

        private void OnClickAuth()
        {
            _authorizationPanel.Show();
            Hide();
        }
    }
}