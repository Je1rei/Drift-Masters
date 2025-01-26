using Levels;
using UnityEngine;


namespace Data
{
    [CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapData", order = 2)]
    public class MapData : ScriptableObject
    {
        [field: SerializeField] public StartPoint StartPoint { get; private set; }
        [field: SerializeField] public LevelBase LevelBasePrefab { get; private set; }
        [field: SerializeField] public LevelItemMapRequiredToWin LevelItemMapRequiredToWinPrefab { get; private set; }
        [field: SerializeField] public LevelFence LevelFencePrefab { get; private set; }
        [field: SerializeField] public LevelSidewalk LevelSidewalkPrefab { get; private set; }
        
        [field: SerializeField] public LevelItemMap LevelItem3PointsMapPrefab { get; private set; }
        [field: SerializeField] public LevelItemMap LevelItem5PointsMapPrefab { get; private set; }
        [field: SerializeField] public LevelBarriersMap LevelBarriersMap { get; private set; }

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