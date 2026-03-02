using Data;
using Inputs;
using Levels;
using Players;
using Services;
using UnityEngine;

namespace Infrastructure.Factories
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Create(TutorialService tutorialService, 
            MapData map, 
            WalletGamePlay wallet,
            AudioService audioService, 
            InputPause inputPause,
            CarData data, 
            StartPoint startPosition)
        {
            MapData mapData = map;

            CarFactory factory = new CarFactory();
            Car car = factory.Create(data.CarViewPrefab, _player.transform);

            _player.Construct(tutorialService, car, mapData.CountRequiredToWinItems, mapData.CountAllItems,
                audioService, wallet, inputPause, startPosition);
            data.CarViewPrefab.gameObject.SetActive(true);
        }
    }
}