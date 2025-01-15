using Data;
using UnityEngine;

namespace Services
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Create(CarData data, Vector3 startPoint)
        {
            _player.Construct(startPoint);
            Car car = Instantiate(data.CarViewPrefab, _player.transform);
        }
    }
}