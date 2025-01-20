using Services;
using UnityEngine;

namespace UIView
{
    public class TutorialPanel : UIPanel
    {
        [SerializeField] private TutorialStepPanel[] _tutorialStepPanels;

        private TutorialService _tutorialService;

        private int _index;

        public void Construct(AudioService audioService, TutorialService tutorialService)
        {
            _tutorialService = tutorialService;
            
            foreach (TutorialStepPanel step in _tutorialStepPanels)
            {
                step.Construct(audioService);
                step.Clicked += ShowNextTutorial;
            }
            
            if (_tutorialService.IsActive)
            {
                Show();
                SetupSequenceTutorials();
            }
        }
        
        private void SetupSequenceTutorials()
        {
            foreach (var panel in _tutorialStepPanels)
            {
                panel.gameObject.SetActive(false);
            }

            if (_tutorialStepPanels.Length > 0)
            {
                _index = 0;
                _tutorialStepPanels[_index].gameObject.SetActive(true);
            }
        }

        private void ShowNextTutorial()
        {
            if (_index < _tutorialStepPanels.Length)
            {
                _tutorialStepPanels[_index].gameObject.SetActive(false);
                _index++;

                if (_index < _tutorialStepPanels.Length)
                {
                    _tutorialStepPanels[_index].gameObject.SetActive(true);
                }
                else
                {
                    CompleteTutorial();
                }
            }
        }

        private void CompleteTutorial()
        {
            Debug.Log("Tutorial Complete");
            _tutorialService.Deactivate();
        }
    }
}