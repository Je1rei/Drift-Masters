using System.Linq;
using Data;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace UIView
{
    public class LevelsPanel : UIPanel
    {
        [SerializeField] private MainMenuPanel _mainMenu;
        [SerializeField] private Level[] _levels;
        [SerializeField] private Button _backButton;

        [SerializeField] private LevelPage[] _levelPages;
        [SerializeField] private Button _previousPageButton;
        [SerializeField] private Button _nextPageButton;

        private AudioService _audioService;
        private LevelService _levelService;
        private SceneLoaderService _sceneLoaderService;

        private int _currentPageIndex;

        private void OnEnable()
        {
            int lastOpenedLevelID = -1;
            
            if (YG2.saves.OpenedLevels.Count > 0)
            {
                lastOpenedLevelID = YG2.saves.OpenedLevels.Max();
            }
            
            for (int i = 0; i < _levels.Length; i++)
            {
                LevelData levelData = _levelService.Load(i);

                if (levelData != null && YG2.saves.OpenedLevels.Contains(levelData.ID))
                {
                    _levels[i].SetUnlock();
                }
                else
                {
                    Debug.Log(levelData.ID + "lock");
                    _levels[i].SetLock();
                }
                
                int levelIndex = i;
                AddButtonListener(_audioService, _levels[i].Button, () => OnClickLevel(levelIndex));
                
                if (levelData != null && levelData.ID == lastOpenedLevelID)
                {
                    _levels[i].Activate();
                }
            }

            AddButtonListener(_audioService, _previousPageButton, OnClickPreviousPage);
            AddButtonListener(_audioService, _nextPageButton, OnClickNextPage);
            AddButtonListener(_audioService, _backButton, OnClickBack);
            SwitchPage(0);
        }

        private void OnDisable()
        {
            foreach (Level level in _levels)
                level.Button.onClick.RemoveAllListeners();

            _previousPageButton.onClick.RemoveAllListeners();
            _nextPageButton.onClick.RemoveAllListeners();
            _backButton.onClick.RemoveAllListeners();
        }

        public void Construct(AudioService audioService, LevelService levelService,
            SceneLoaderService sceneLoaderService)
        {
            _audioService = audioService;
            _levelService = levelService;
            _sceneLoaderService = sceneLoaderService;
        }

        private void OnClickLevel(int index)
        {
            LevelData levelData = _levelService.Load(index);

            if (levelData != null)
            {
                Hide();
                SceneManager.LoadScene(_sceneLoaderService.GamePlayScene);
            }
        }

        private void OnClickBack()
        {
            _mainMenu.Show();
            Hide();
        }

        private void OnClickPreviousPage()
        {
            if (_currentPageIndex > 0)
            {
                SwitchPage(_currentPageIndex - 1);
            }
        }

        private void OnClickNextPage()
        {
            if (_currentPageIndex < _levelPages.Length - 1)
            {
                SwitchPage(_currentPageIndex + 1);
            }
        }

        private void SwitchPage(int index)
        {
            if (index < 0 || index >= _levelPages.Length) return;

            foreach (LevelPage page in _levelPages)
                page.Hide();

            _levelPages[index].Show();
            _currentPageIndex = index;

            _previousPageButton.interactable = _currentPageIndex > 0;
            _nextPageButton.interactable = _currentPageIndex < _levelPages.Length - 1;
        }
    }
}