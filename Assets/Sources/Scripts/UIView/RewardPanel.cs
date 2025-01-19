using Data;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace UIView
{
    public class RewardPanel : UIPanel
    {
        [SerializeField] private GameplayPanel _gameplayPanel;
        [SerializeField] private Button _claimButton;
        [SerializeField] private Button _claimADButton;
        [SerializeField] private TMP_Text _textCoinsReward;

        private AudioService _audioService;
        private SceneLoaderService _sceneLoader;
        private RewardService _rewardService;
        private LevelService _levelService;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _claimButton, OnClickClaim);
            AddButtonListener(_audioService, _claimADButton, OnClickAdClaim);
        }

        private void OnDisable()
        {
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
        
        private void Reward(int value)
        {
            _textCoinsReward.text = value.ToString();

            if (this != null)
            {
                Show();
            }
        }
        
        private void OnClickAdClaim()
        {
            _rewardService.RewardAd();
            
            Hide();
            OnClickClaim();
        }

        private void OnClickClaim()
        {
            Hide();

            int tempIndex = _levelService.ID;
            LevelData leveldata = _levelService.Load(tempIndex);

            if (leveldata != null)
            {
                YG2.InterstitialAdvShow();

                SceneManager.LoadScene(_sceneLoader.GamePlayScene);
            }
            else
            {
                SceneManager.LoadScene(_sceneLoader.MainMenuScene);
            }
        }
    }
}