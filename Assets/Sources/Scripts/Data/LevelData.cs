using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int ID;
        public MapData Map;
    }
}