using Data;
using Infrastructure;
using Inputs;
using UnityEngine;

namespace Services
{
    public class LevelFactory : MonoBehaviour
    {
        [SerializeField] private MapFactory _mapFactory;
        [SerializeField] private PlayerFactory _playerFactory;

        public void Create(WalletGamePlay wallet, AudioService audioService, InputPause inputPause, LevelData levelData,
            CarData carData)
        {
            _mapFactory.Create(levelData.Map);
            _playerFactory.Create(levelData.Map, wallet, audioService, inputPause, carData,
                levelData.Map.StartPoint.transform.position);
        }
    }
}