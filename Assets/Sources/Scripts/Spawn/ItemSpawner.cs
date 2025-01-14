using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class ItemSpawner : SpawnerObjects<Item>
    {
        [FormerlySerializedAs("_offset")]
        [Space(20)]
        [SerializeField] private Vector3 offset;

        [FormerlySerializedAs("_spawnPoints")]
        [Space(10)] 
        [SerializeField] private List<SpawnPoint> spawnPoints = new ();

        private int _countItemSpawn = 4;
        private List<Item> _itemsToCompleteLevel = new ();

        public event Action ItemsEnded; 

        private void Awake()
        {
            CreatePool();

            if (_countItemSpawn > spawnPoints.Count)
            {
                Debug.LogWarning("Item spawn count is " + spawnPoints.Count);
                _countItemSpawn = spawnPoints.Count;
            }
            
            StartCreation();
        }

        public void RestartGame()
        {
            ResetAllPool();
            StartCreation();
        }

        public void Collect(Item item)
        {
            if (item.IsRequiredCompleteLevel && _itemsToCompleteLevel.Contains(item))
            {
                _itemsToCompleteLevel.Remove(item);
            }
            
            if(_itemsToCompleteLevel.Count == 0)
            {
                ItemsEnded?.Invoke();
                Debug.LogWarning("Finished item");
            }

            ReturnToPool(item);
        }

        private void StartCreation()
        {
            var points = GetSpawnPoints();

            foreach (var point in points)
            {
                var item = Spawn(point, Quaternion.identity);
                
                if (item.IsRequiredCompleteLevel)
                {
                    _itemsToCompleteLevel.Add(item);
                }
            }
        }

        private List<Vector3> GetSpawnPoints()
        {
            List<Vector3> spawnPoints = new();
            
            foreach (var point in this.spawnPoints)
            {
                if (point.Spawned)
                {
                  spawnPoints.Add(point.transform.position + offset);   
                }
            }
            
            return spawnPoints;
        }

        private void OnTrasfered(int count)
        {
            _countItemSpawn = count;
        }
    }
}