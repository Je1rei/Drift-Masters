using Data;
using Inputs;
using Services;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class LevelFactory : MonoBehaviour
    {
        [SerializeField] private MapFactory _mapFactory;
        [SerializeField] private PlayerFactory _playerFactory;

        public void Create(TutorialService tutorialService, WalletGamePlay wallet, AudioService audioService, InputPause inputPause, LevelData levelData,
            CarData carData)
        {
            _mapFactory.Create(levelData.Map);
            _playerFactory.Create(tutorialService, levelData.Map, wallet, audioService, inputPause, carData,
                levelData.Map.StartPoint);
        }
    }
}