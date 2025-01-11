using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class MainMenuPanel : UIPanel
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _shopButton;
        [SerializeField] private Button _leaderboardButton;

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private LevelsPanel _levels;
        [SerializeField] private SettingsPanel _settings;
        [SerializeField] private ShopPanel _shop;
        [SerializeField] private LeaderboardPanel _leaderboard;

        private AudioService _audioService;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _playButton, OnClickPlay);
            AddButtonListener(_audioService, _settingsButton, OnClickSettings);
            AddButtonListener(_audioService, _shopButton, OnClickShop);
            AddButtonListener(_audioService, _leaderboardButton, OnClickLeaderboard);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _shopButton.onClick.RemoveAllListeners();
            _leaderboardButton.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService, LevelService levelService, SettingsService settingsService,
            SceneLoaderService sceneLoaderService)
        {
            _audioService = audioService;

            _leaderboard.Construct(_audioService);
            _levels.Construct(_audioService, levelService, sceneLoaderService);
            _settings.Construct(_audioService, settingsService);
            _shop.Construct(_audioService);
        }

        private void OnClickPlay()
        {
            _levels.Show();
        }

        private void OnClickSettings()
        {
            _settings.Show();
        }

        private void OnClickShop()
        {
            _shop.Show();
        }

        private void OnClickLeaderboard()
        {
            _leaderboard.Show();
        }
    }
}