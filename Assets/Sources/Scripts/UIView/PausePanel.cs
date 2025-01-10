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

        private SceneLoaderService _sceneLoader;
        
        private void OnEnable()
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
            
            // SetAudioService();
            AddButtonListener(_continueButton, OnClickUnPause);
            AddButtonListener(_backToMenuButton, OnClickBackToMenu);
            AddButtonListener(_restartButton, OnClickReset);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveAllListeners();
            _backToMenuButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
        }
        
        [Inject]
        private void Construct(SceneLoaderService sceneLoader)
        {
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
            SceneManager.LoadScene(_sceneLoader.GamePlayScene);
        }
    }
}