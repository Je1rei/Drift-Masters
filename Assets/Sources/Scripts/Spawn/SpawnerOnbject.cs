using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawn
{
    public class SpawnerObjects <T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T _object;
        [Space(10)]
        [SerializeField] protected int _initialPoolSize = 24;

        private List<T> _pool = new ();
    
        protected void CreatePool()
        { 
            InstantiatePool();
            ResetAllPool();
        }

        protected T Spawn(Vector3 position, Quaternion rotation)
        {
            while (_pool.FirstOrDefault(obj => obj.gameObject.activeSelf == false) == null)
            {
                Debug.LogWarning("Objects in Poos is End=");
                AddToPool();
            }

            T obj = _pool.FirstOrDefault(obj => obj.gameObject.activeSelf==false);
      
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            
            obj.gameObject.SetActive(true);
            
            return obj;
        }
    
        protected void ReturnToPool(T obj)
        {
            if (_pool.FirstOrDefault(obj => obj) != null)
            {
                obj.gameObject.SetActive(false);
            }
        }

        protected void ResetAllPool()
        {
            foreach (var obj in _pool)
            {
                obj.gameObject.SetActive(false);
            }
        }

        private void InstantiatePool()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                AddToPool();
            }
        }

        private void AddToPool()
        {
            _pool.Add(Instantiate(_object, transform));
        }
    }
}
