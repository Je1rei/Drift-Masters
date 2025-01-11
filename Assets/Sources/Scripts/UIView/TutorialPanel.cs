using Services;
using UnityEngine;

namespace UIView
{
    public class TutorialPanel : UIPanel
    {
        [SerializeField] private TutorialStepPanel[] _tutorialPanels;

        private TutorialService _tutorialService;

        private int _currentIndex;

        public void Construct()
        {
            if (_tutorialService.IsActive)
            {
                Show();
                SetupSequenceTutorials();
                
                //inputHandler.Clicked += ShowNextTutorial;
            }
        }
        
        private void SetupSequenceTutorials()
        {
            foreach (var panel in _tutorialPanels)
            {
                panel.gameObject.SetActive(false);
            }

            if (_tutorialPanels.Length > 0)
            {
                _currentIndex = 0;
                _tutorialPanels[_currentIndex].gameObject.SetActive(true);
            }
        }

        private void ShowNextTutorial()
        {
            if (_currentIndex < _tutorialPanels.Length)
            {
                _tutorialPanels[_currentIndex].gameObject.SetActive(false);
                _currentIndex++;

                if (_currentIndex < _tutorialPanels.Length)
                {
                    _tutorialPanels[_currentIndex].gameObject.SetActive(true);
                }
                else
                {
                    CompleteTutorial();
                }
            }
        }

        private void CompleteTutorial()
        {
            // _swipeInputHandler.Clicked -= ShowNextTutorial;
            // _service.Deactivate();
        }
    }
}