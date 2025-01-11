using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class ItemSpawner : SpawnerObjects<Item>
    {
        [Space(20)]
        [SerializeField] private Vector3 _offset;

        [Space(10)] 
        [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

        private int _countItemSpawn = 4;
        private List<Item> _itemsToCompleteLevel = new List<Item>();

        public event Action ItemsEnded; 

        private void Awake()
        {
            CreatePool();

            if (_countItemSpawn > _spawnPoints.Count)
            {
                Debug.LogWarning("Item spawn count is " + _spawnPoints.Count);
                _countItemSpawn = _spawnPoints.Count;
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
            for (int i = 0; i < _countItemSpawn; i++)
            {
                Vector3 position = GetSpawnPoint() + _offset;
                var item = Spawn(position, Quaternion.identity);

                if (item.IsRequiredCompleteLevel)
                {
                    _itemsToCompleteLevel.Add(item);
                }
            }
        }

        private Vector3 GetSpawnPoint()
        {
            int index = Random.Range(0, _spawnPoints.Count);
            Vector3 position = _spawnPoints[index].transform.localPosition;
            
            return position;
        }

        private void OnTrasfered(int count)
        {
            _countItemSpawn = count;
        }
    }
}