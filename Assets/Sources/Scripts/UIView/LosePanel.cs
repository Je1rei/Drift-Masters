using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UIView
{
    public class LosePanel : UIPanel
    {
        [SerializeField] private GameplayPanel _gameplayPanel;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _continueAdButton;
        [SerializeField] private Button _restartButton;

        private RewardService _rewardService;
        private SceneLoaderService _sceneLoader;
        
        private void OnEnable()
        {
            //SetAudioService();
            AddButtonListener(_restartButton, OnClickReset);
            AddButtonListener(_backToMenuButton, OnClickBackToMenu);
            AddButtonListener(_continueAdButton, OnClickContinueAD);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _backToMenuButton.onClick.RemoveAllListeners();
            _continueAdButton.onClick.RemoveAllListeners();

            _rewardService.Losed -= Lose;
        }

        [Inject]
        public void Construct(RewardService rewardService, SceneLoaderService sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _rewardService = rewardService;
            _rewardService.Losed += Lose;
        }

        private void Lose()
        {
            if (this != null)
            {
                Show();
                _gameplayPanel.Hide();
            }
        }

        private void OnClickReset()
        {
            SceneManager.LoadScene(_sceneLoader.GamePlayScene);
        }

        private void OnClickBackToMenu()
        {
            SceneManager.LoadScene(_sceneLoader.MainMenuScene);
        }

        private void OnClickContinueAD()
        {
            //логика продолжения
        }
    }
}