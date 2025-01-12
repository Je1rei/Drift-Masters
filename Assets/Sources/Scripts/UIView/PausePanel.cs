using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UIView
{
    public class PausePanel : UIPanel
    {
        [SerializeField] private GameplayPanel _gameplayPanel;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;

        private AudioService _audioService;
        private SceneLoaderService _sceneLoader;

        private void OnEnable()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;

            AddButtonListener(_audioService, _continueButton, OnClickUnPause);
            AddButtonListener(_audioService, _backToMenuButton, OnClickBackToMenu);
            AddButtonListener(_audioService, _restartButton, OnClickReset);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveAllListeners();
            _backToMenuButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService, SceneLoaderService sceneLoader)
        {
            _audioService = audioService;
            _sceneLoader = sceneLoader;
        }

        public void Pause()
        {
            Show();
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }

        public void OnClickUnPause()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            Hide();
            _gameplayPanel.UnPause();
        }

        private void OnClickBackToMenu()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            SceneManager.LoadScene(_sceneLoader.MainMenuScene);
        }

        private void OnClickReset()
        {
            AudioListener.pause = false;
            SceneManager.LoadScene(_sceneLoader.GamePlayScene);
        }
    }
}