using Data;
using DG.Tweening;
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
        
        private int _lastReward;
        
        private readonly Sequence _sequence;
        
        private LevelService _levelService;
        private AudioService _audioService;
        private SceneLoaderService _sceneLoader;
        private RewardService _rewardService;

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

        public void Construct(AudioService audioService, 
            RewardService rewardService,
            LevelService levelService,
            SceneLoaderService sceneLoader)
        {
            _audioService = audioService;
            _sceneLoader = sceneLoader;
            _rewardService = rewardService;
            _levelService = levelService;

            _rewardService.Rewarded += Reward;
        }

        private void Reward(int value, bool showed)
        {
            _lastReward = value;
            _textCoinsReward.text = value.ToString();

            if (this != null && showed == false)
            {
                Show();
            }
        }

        private void OnClickAdClaim()
        {
            _rewardService.RewardAd(_lastReward);
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
                Hide();
            }
            else
            {
                SceneManager.LoadScene(_sceneLoader.MainMenuScene);
            }
        }
    }
}