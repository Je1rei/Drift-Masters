using Data;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

namespace UIView
{
    public class RewardPanel : UIPanel
    {
        [SerializeField] private GameplayPanel _gameplayPanel;
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private Button _claimButton;
        [SerializeField] private Button _claimADButton;

        private AudioService _audioService;
        private SceneLoaderService _sceneLoader;
        private RewardService _rewardService;
        private LevelService _levelService;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _backToMenuButton, OnClickBackToMenu);
            AddButtonListener(_audioService, _claimButton, OnClickClaim);
            AddButtonListener(_audioService, _claimADButton, OnClickAdClaim);
        }

        private void OnDisable()
        {
            _backToMenuButton.onClick.RemoveAllListeners();
            _claimButton.onClick.RemoveAllListeners();
            _claimADButton.onClick.RemoveAllListeners();

            _rewardService.Rewarded -= Reward;
        }

        public void Construct(AudioService audioService, RewardService rewardService, LevelService levelService,
            SceneLoaderService sceneLoader)
        {
            _audioService = audioService;
            _sceneLoader = sceneLoader;
            _rewardService = rewardService;
            _levelService = levelService;

            _rewardService.Rewarded += Reward;
        }

        private void Reward()
        {
            if (this != null)
            {
                Show();
                _gameplayPanel.Hide();
            }
        }

        private void OnClickAdClaim()
        {
            //сделать окно с добычей и кнопкой на следующий уровень
            Hide();
        }

        private void OnClickClaim()
        {
            //сделать окно с добычей и кнопкой на следующий уровень
            Hide();
        }

        private void OnClickBackToMenu()
        {
            SceneManager.LoadScene(_sceneLoader.MainMenuScene);
        }

        private void OnClickNextLevel() //сделать окно с добычей и кнопкой на следующий уровень
        {
            int tempIndex = _levelService.ID;
            LevelData leveldata = _levelService.Load(tempIndex);

            if (leveldata != null)
            {
                YG2.InterstitialAdvShow();

                SceneManager.LoadScene(_sceneLoader.GamePlayScene);
            }
            else
            {
                // _nextLevelButton.gameObject.SetActive(false); // сделать окно с добычей и кнопкой на следующий уровень
            }
        }
    }
}