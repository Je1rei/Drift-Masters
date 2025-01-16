using Data;
using Infrastructure;
using Inputs;
using UnityEngine;

namespace Services
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Create(WalletGamePlay wallet, InputPause inputPause, CarData data, Vector3 startPosition)
        {
            _player.Construct(wallet, inputPause, startPosition);
            CarFactory factory = new CarFactory();
            factory.Create(data.CarViewPrefab, _player.transform);
            data.CarViewPrefab.gameObject.SetActive(true);
        }
    }
}