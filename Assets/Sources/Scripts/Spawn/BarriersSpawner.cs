using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class BarriersSpawner : SpawnerObjects<Barrier>
    {
        [Space(20)] [SerializeField] private Vector3 _offset;

        [Space(10)] [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();

        private int _countBarrierSpawn = 4;

        private void Awake()
        {
            CreatePool();

            if (_countBarrierSpawn > _spawnPoints.Count)
            {
                Debug.LogWarning("Item spawn count is " + _spawnPoints.Count);
                _countBarrierSpawn = _spawnPoints.Count;
            }

            StartCreation();
        }

        public void RestartGame()
        {
            ResetAllPool();
            StartCreation();
        }

        private void StartCreation()
        {
            for (int i = 0; i < _countBarrierSpawn; i++)
            {
                Vector3 position = GetSpawnPoint() + _offset;
                var item = Spawn(position, Quaternion.identity);
            }
        }

        private Vector3 GetSpawnPoint()
        {
            int index = Random.Range(0, _spawnPoints.Count);
            Vector3 position = _spawnPoints[index].transform.localPosition;

            return position;
        }
    }
}