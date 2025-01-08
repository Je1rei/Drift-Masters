using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    public int ID;
    public MapData MapData;
    public int RequiredItemToWin;

#if UNITY_EDITOR
    private void OnValidate()
    {
        // if (MapData != null && MapData.Map.SpawnPoints.Length < RequiredItemToWin)
        // {
        //     Debug.LogWarning($"RequiredItemToWin is greater than the number of spawn points in MapData. " +
        //                      $"Spawn Points: {MapData.Map.SpawnPoints.Length}, RequiredItemToWin: {RequiredItemsToWin}");
        //     RequiredItemToWin = MapData.Map.SpawnPoints.Length;
        // }
    }
#endif
}