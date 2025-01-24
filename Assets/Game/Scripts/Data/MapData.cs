using Levels;
using UnityEngine;
using NaughtyAttributes;

namespace Data
{
    [CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapData", order = 2)]
    public class MapData : ScriptableObject
    {
        [Foldout("Обязательные компоненты")] public StartPoint StartPoint;
        [Foldout("Обязательные компоненты")] public LevelBase LevelBasePrefab;
        [Foldout("Обязательные компоненты")] public LevelItemMapRequiredToWin LevelItemMapRequiredToWinPrefab;
        [Foldout("Обязательные компоненты")] public LevelFence LevelFencePrefab;
        [Foldout("Обязательные компоненты")] public LevelSidewalk LevelSidewalkPrefab;
        
        [Foldout("Дополнительно")] public LevelItemMap LevelItem3PointsMapPrefab;
        [Foldout("Дополнительно")] public LevelItemMap LevelItem5PointsMapPrefab;
        [Foldout("Дополнительно")] public LevelBarriersMap LevelBarriersMap;

        public int CountRequiredToWinItems => GetChildCount(LevelItemMapRequiredToWinPrefab);

        public int CountAllItems =>
            GetChildCount(LevelItem3PointsMapPrefab) +
            GetChildCount(LevelItem5PointsMapPrefab) +
            GetChildCount(LevelItemMapRequiredToWinPrefab);

        private int GetChildCount(Component levelItem)
        {
            return levelItem?.GetComponentsInChildren<Transform>(false).Length - 1 ?? 0;
        }
    }
}