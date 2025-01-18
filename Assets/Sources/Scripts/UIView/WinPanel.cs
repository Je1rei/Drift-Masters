using Services;
using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class WinPanel : UIPanel
    {
        [SerializeField] private RewardPanel _rewardPanel;

        private RewardService _rewardService;

        private void OnDisable()
        {
            _rewardService.PreparedRewarded -= OnRewarded;
        }

        public void Construct(RewardService rewardService)
        {
            _rewardService = rewardService;
            _rewardService.PreparedRewarded += OnRewarded;
        }

        private void OnRewarded()
        {
            Show();
        }
    }
}