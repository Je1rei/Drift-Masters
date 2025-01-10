using UnityEngine;
using UnityEngine.UI;

namespace UIView
{
    public class GameplayPanel : UIPanel
    {
        [SerializeField] private TutorialPanel _tutorialPanel;
        [SerializeField] private PausePanel _pausePanel;
        [SerializeField] private Button _backButton;

        private void OnEnable()
        {
            Time.timeScale = 1f;

            AddButtonListener(_backButton, Pause);
        }

        private void OnDisable()
        {
            _backButton.onClick.RemoveAllListeners();
        }

        public void Init()
        {
            //SetAudioService();
            Show();
            //_tutorialPanel.Init();
        }

        public void Pause()
        {
            Hide();
            _pausePanel.Pause();
        }

        public void UnPause()
        {
            Show();
        }
    }
}