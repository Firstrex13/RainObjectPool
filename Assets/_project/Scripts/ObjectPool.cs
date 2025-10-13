using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> _pool = new Queue<T>();

    private T _prefab;

    public event Action Activated;
    public event Action Returned;
    public event Action Instantiated;

    public ObjectPool(T prefab, int count)
    {
        _prefab = prefab;

        for (int i = 0; i < count; i++)
        {
            _pool.Enqueue(fillUpPool());
        }
    }

    public T GetFromPool()
    {
        if (_pool.Count > 0)
        {
            T obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            Activated?.Invoke();
            return obj;
        }
        else
        {
            Instantiated?.Invoke();
            return Object.Instantiate(_prefab);
        }
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);     

        _pool.Enqueue(obj);

        Returned?.Invoke();
    }

    private T fillUpPool()
    {
        T obj = Object.Instantiate(_prefab);
        obj.gameObject.SetActive(false);

        return obj;
    }
}
