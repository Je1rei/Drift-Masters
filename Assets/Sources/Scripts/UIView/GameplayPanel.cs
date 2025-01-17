using Inputs;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIView
{
    public class GameplayPanel : UIPanel
    {
        [SerializeField] private TutorialPanel _tutorialPanel;
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private LosePanel _losePanel;
        [SerializeField] private RewardPanel _rewardPanel;
        [SerializeField] private WinPanel _winPanel;
        
        [SerializeField] private Button _backButton;

        private AudioService _audioService;
        
        private void OnEnable()
        {
            Time.timeScale = 1f;
            AddButtonListener(_audioService, _backButton, Pause);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
        }

        public void Construct(InputPause inputPause, AudioService audioService, RewardService rewardService, LevelService levelService, SceneLoaderService sceneLoaderService)
        {
            _audioService = audioService;
            _rewardPanel.Construct(audioService, rewardService, levelService, sceneLoaderService);
            _losePanel.Construct(inputPause, audioService, rewardService, sceneLoaderService);
            _pausePanel.Construct(audioService, sceneLoaderService);
            _winPanel.Construct(audioService, rewardService);
            
            Show();
            //_tutorialPanel.Init();
        }

        public void Pause()
        {
            _pausePanel.Pause();
        }

        public void UnPause()
        {
            Show();
        }
    }
}