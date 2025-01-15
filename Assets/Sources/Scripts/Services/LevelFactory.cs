using Data;
using UnityEngine;

namespace Services
{
    public class LevelFactory : MonoBehaviour
    {
        [SerializeField] private MapFactory _mapFactory;
        [SerializeField] private PlayerFactory _playerFactory;

        public void Create(LevelData levelData, CarData carData)
        {
            _mapFactory.Create(levelData.Map);
            _playerFactory.Create(carData, levelData.Map.StartPoint.transform.position);
        }
    }
}