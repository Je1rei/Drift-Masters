using Data;
using UnityEngine;

namespace Services
{
    public class MapFactory : MonoBehaviour
    {
        [SerializeField] private Transform _transformParent;
        
        public void Create(MapData data)
        {
            StartPoint startPoint = Instantiate(data.StartPoint, _transformParent);
            
            LevelBase levelBase = Instantiate(data.LevelBasePrefab, _transformParent);
            LevelSidewalk levelSidewalk = Instantiate(data.LevelSidewalkPrefab, _transformParent);
            LevelFence levelFencePrefab = Instantiate(data.LevelFencePrefab, _transformParent);

            LevelItemMapRequiredToWin levelItemsRequiredToWin = Instantiate(data.LevelItemMapRequiredToWinPrefab, _transformParent);
            LevelItemMap levelItems3Points = Instantiate(data.LevelItem3PointsMapPrefab, _transformParent);
            LevelItemMap levelItems5Points = Instantiate(data.LevelItem5PointsMapPrefab, _transformParent);

            LevelBarriersMap levelBarriersMap = Instantiate(data.LevelBarriersMap, _transformParent);
        }
    }
}