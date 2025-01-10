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

        private void OnEnable()
        {
            //SetAudioService();
            AddButtonListener(_playButton, OnClickPlay);
            AddButtonListener(_settingsButton, OnClickSettings);
            AddButtonListener(_shopButton, OnClickShop);
            AddButtonListener(_leaderboardButton, OnClickLeaderboard);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _shopButton.onClick.RemoveAllListeners();
            _leaderboardButton.onClick.RemoveAllListeners();
        }

        private void OnClickPlay()
        {
            _levels.Show();
            Hide();
        }

        private void OnClickSettings()
        {
            _settings.Show();
            Hide();
        }

        private void OnClickShop()
        {
            _shop.Show();
            Hide();
        }

        private void OnClickLeaderboard()
        {
            _leaderboard.Show();
        }
    }
}