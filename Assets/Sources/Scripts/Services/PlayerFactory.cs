using Data;
using Infrastructure;
using Inputs;
using UnityEngine;

namespace Services
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Create(MapData map, WalletGamePlay wallet, AudioService audioService, InputPause inputPause, CarData data, StartPoint startPosition)
        {
            MapData mapData = map;
            
            _player.Construct(mapData.CountRequiredToWinItems, mapData.CountAllItems, audioService, wallet, inputPause, startPosition);
            CarFactory factory = new CarFactory();
            factory.Create(data.CarViewPrefab, _player.transform);
            data.CarViewPrefab.gameObject.SetActive(true);
        }
    }
}