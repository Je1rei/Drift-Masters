using Data;
using UnityEngine;

namespace Services
{
    public class MapFactory : MonoBehaviour
    {
        [SerializeField] private Transform _transformParent;
        
        public void Create(MapData data)
        {
            Instantiate(data.StartPoint, _transformParent);
            Instantiate(data.LevelBasePrefab, _transformParent);
            
            Instantiate(data.LevelSidewalkPrefab, _transformParent);
            Instantiate(data.LevelFencePrefab, _transformParent);
            Instantiate(data.LevelItemMapRequiredToWinPrefab, _transformParent);
            
            InstantiateIfNotNull(data.LevelItem3PointsMapPrefab);
            InstantiateIfNotNull(data.LevelItem5PointsMapPrefab);
            InstantiateIfNotNull(data.LevelBarriersMap);
            InstantiateIfNotNull(data.LevelBarriersMap);
        }
        
        private void InstantiateIfNotNull<T>(T prefab) where T : Object
        {
            if (prefab != null)
            {
                Instantiate(prefab, _transformParent);
            }
        }
    }
}