using UnityEngine;

public class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    protected ObjectPool<T> _pool;

    protected int ObjectStartCount;

    protected void Created()
    {
        ObjectStartCount++;
    }

    protected virtual void OnReturnToPool(T obj)
    {
        _pool.ReturnObject(obj);
    }
}
