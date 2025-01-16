using Inputs;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

namespace UIView
{
    public class LosePanel : UIPanel
    {
        private const string RewardID = "2";

        [SerializeField] private GameplayPanel _gameplayPanel;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _continueAdButton;
        [SerializeField] private Button _restartButton;

        private InputPause _inputPause;
        private AudioService _audioService;
        private RewardService _rewardService;
        private SceneLoaderService _sceneLoader;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _restartButton, OnClickReset);
            AddButtonListener(_audioService, _backToMenuButton, OnClickBackToMenu);
            AddButtonListener(_audioService, _continueAdButton, OnClickContinueAD);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveAllListeners();
            _backToMenuButton.onClick.RemoveAllListeners();
            _continueAdButton.onClick.RemoveAllListeners();

            _rewardService.Losed -= Lose;
        }

        public void Construct(InputPause inputPause, AudioService audioService, RewardService rewardService,
            SceneLoaderService sceneLoader)
        {
            _inputPause = inputPause;
            _audioService = audioService;
            _sceneLoader = sceneLoader;
            _rewardService = rewardService;

            _rewardService.Losed += Lose;
        }

        private void Lose()
        {
            if (this != null)
            {
                _inputPause.DeactivateInput();
                Show();
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
            YG2.RewardedAdvShow(RewardID, () =>
            {
                Hide();
                
                _rewardService.Continue();
                _inputPause.ActivateInput();
                _rewardService.Losed += Lose;
            });
        }
    }
}