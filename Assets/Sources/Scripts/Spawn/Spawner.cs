using UnityEngine;
using UnityEngine.Pool;

namespace Spawn
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected T _object;
        [Space(10)]
        [SerializeField] protected int initialPoolSize = 16;
        [SerializeField] protected int maxPoolSize = 32;

        private ObjectPool<T> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<T>(
                createFunc: Create,
                actionOnGet: obj => obj.gameObject.SetActive(true),
                actionOnRelease: obj => obj.gameObject.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: false,
                defaultCapacity: initialPoolSize,
                maxSize: maxPoolSize
            );
        }

        protected T Spawn(Vector3 position, Quaternion rotation)
        {
            T obj = _pool.Get();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            return obj;
        }

        protected void ReturnToPool(T obj)
        {
            _pool.Release(obj);
        }

        private T Create()
        {
            T obj = Instantiate(_object, transform);
            return obj;
        }
    }
}