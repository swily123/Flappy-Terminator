using UnityEngine;
using UnityEngine.Pool;

namespace Spawners
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _objectPrefab;

        private readonly int _defaultCapacity = 1;
        private readonly int _poolMaxSize = 30;
        private ObjectPool<T> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<T>(
                createFunc: Spawn,
                actionOnGet: ActionOnGet,
                actionOnRelease: ActionOnRelease,
                actionOnDestroy: (obj) => Destroy(obj.gameObject),
                collectionCheck: true,
                defaultCapacity: _defaultCapacity,
                maxSize: _poolMaxSize);
        }

        protected void ReleaseObject(T @object)
        {
            _pool.Release(@object);
        }

        protected T GetObject()
        {
            return _pool.Get();
        }

        private void ActionOnGet(T @object)
        {
            @object.gameObject.SetActive(true);
            @object.transform.position = transform.position;
        }

        private void ActionOnRelease(T @object)
        {
            @object.gameObject.SetActive(false);
        }

        private T Spawn()
        {
            T @object = Instantiate(_objectPrefab);
            return @object;
        }
    }
}
