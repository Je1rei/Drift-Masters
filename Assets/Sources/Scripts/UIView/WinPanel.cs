using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class WinPanel : UIPanel
    {
        [SerializeField] private RewardPanel _rewardPanel;
        [SerializeField] private Button _continueButton;

        private RewardService _rewardService;
        private AudioService _audioService;

        private void OnEnable()
        {
            AddButtonListener(_audioService, _continueButton, OnClickContinue);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveAllListeners();
            _rewardService.BetweenRewarded -= OnRewarded;
        }

        public void Construct(AudioService audioService, RewardService rewardService)
        {
            _audioService = audioService;
            _rewardService = rewardService;
            
            _rewardService.BetweenRewarded += OnRewarded;
        }

        private void OnRewarded()
        {
            Show();
        }
        
        private void OnClickContinue()
        {
            _rewardPanel.Show();
            Hide();
        }
    }
}