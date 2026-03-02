using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public MapData Map { get; private set; }
    }
}