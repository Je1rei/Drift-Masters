using Data;
using UnityEngine;

namespace Services
{
    public class LevelFactory : MonoBehaviour
    {
        public void Create(LevelData data, Transform parent) // Call in Level Init script from start the gameplayScene
        {
            // Instantiate Map(MapFactory)
            // Instantiate Environment prefabs
            // Set RequiredItemToWin
        }
    }
}