using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private bool spawned = false;
        
        public bool Spawned => spawned;
    }
}