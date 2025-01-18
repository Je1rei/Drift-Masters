using UnityEngine;
using NaughtyAttributes;

namespace Data
{
    [CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapData", order = 2)]
    public class MapData : ScriptableObject
    {
        [Required("Укажите точку спавна машины")] public StartPoint StartPoint;
        [Required("Укажите базу для уровня")] public LevelBase LevelBasePrefab;
        [Required("Укажите обязательные итемы для победы")] public LevelItemMapRequiredToWin LevelItemMapRequiredToWinPrefab;
        [Required("Укажите ограду")]public LevelFence LevelFencePrefab;
        [Required("Укажите тротуар")]public LevelSidewalk LevelSidewalkPrefab;
        
        public LevelItemMap LevelItem3PointsMapPrefab;
        public LevelItemMap LevelItem5PointsMapPrefab;
        public LevelBarriersMap LevelBarriersMap;

        public int CountRequiredToWinItems =>
            LevelItemMapRequiredToWinPrefab.GetComponentsInChildren<Transform>(false).Length - 1;

        public int CountAllItems => (LevelItem3PointsMapPrefab?.GetComponentsInChildren<Transform>(false).Length ?? 0) +
            (LevelItem5PointsMapPrefab?.GetComponentsInChildren<Transform>(false).Length ?? 0) +
            (LevelItemMapRequiredToWinPrefab?.GetComponentsInChildren<Transform>(false).Length ?? 0) - 3;
    }
}