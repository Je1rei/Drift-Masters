using Data;
using Infrastructure;
using Inputs;
using UIView;
using UnityEngine;

namespace Services
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Create(MapData map, WalletGamePlay wallet, InputPause inputPause, CarData data, Vector3 startPosition)
        {
            MapData mapData = map;
            
            _player.Construct(mapData.CountRequiredToWinItems, mapData.CountAllItems, wallet, inputPause, startPosition);
            CarFactory factory = new CarFactory();
            factory.Create(data.CarViewPrefab, _player.transform);
            data.CarViewPrefab.gameObject.SetActive(true);
        }
    }
}