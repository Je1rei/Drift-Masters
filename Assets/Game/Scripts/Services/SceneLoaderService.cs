using NaughtyAttributes;
using UnityEngine;

namespace Services
{
    public class SceneLoaderService : MonoBehaviour
    {
        [Scene] [SerializeField] private int _mainMenuScene;
        [Scene] [SerializeField] private int _gamePlayScene;

        public int MainMenuScene => _mainMenuScene;
        public int GamePlayScene => _gamePlayScene;
    }
}