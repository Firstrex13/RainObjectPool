using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> _pool = new Queue<T>();

    private T _prefab;
    private int _poolCapacity = 5;

    public ObjectPool(T prefab)
    {
        _prefab = prefab;

        for (int i = 0; i < _poolCapacity; i++)
        {
            ReturnCube(_prefab);
        }
    }

    public T GetFromPool()
    {
        if (_pool.Count > 0)
        {
            T obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            return Object.Instantiate(_prefab);
        }
    }

    public void ReturnCube(T obj)
    {
        obj.gameObject.SetActive(false);
        
        _pool.Enqueue(obj);
    }
}
