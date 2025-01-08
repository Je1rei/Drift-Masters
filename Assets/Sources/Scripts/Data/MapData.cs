using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/MapData", order = 2)]
public class MapData : ScriptableObject
{
    public EnvironmentData EnvironmentData;
    // public SpawnPoint[] SpawnPoints; => переместить в Map свойство
    // public Map MapPrefab;
}