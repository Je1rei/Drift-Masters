using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapData", order = 2)]
    public class MapData : ScriptableObject
    {
        [Header("Точка спавна машины")]
        public StartPoint StartPoint;
        
        [Space(10)] 
        [Header("Настройки для конструктора")]
        public LevelBase LevelBasePrefab;
        public LevelSidewalk LevelSidewalkPrefab;
        public LevelFence LevelFencePrefab;
        
        [Space(10)]
        [Header("Карты итемов")]
        public LevelItemMapRequiredToWin LevelItemMapRequiredToWinPrefab;
        public LevelItemMap LevelItem3PointsMapPrefab;
        public LevelItemMap LevelItem5PointsMapPrefab;
        
        [Space(10)] 
        [Header("Карты барьеров")]
        public LevelBarriersMap LevelBarriersMap;
    }
}