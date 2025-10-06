using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Queue<Cube> _pool = new Queue<Cube>();

    [SerializeField] private Cube _prefab;

    private int _poolCapacity = 10;

    private void Start()
    {
        for (int i = 0; i < _poolCapacity; i++)
        {
            _pool.Enqueue(Instantiate(_prefab));

        }

        foreach (var item in _pool)
        {
            item.gameObject.SetActive(false);
            item.Initialize(this);
        }
    }

    public Cube GetFromPool()
    {
        if (_pool.Count <= 0)
        {
            ExpandPool();
        }

        Cube cube = _pool.Dequeue();
        cube.gameObject.SetActive(true);
        return cube;
    }

    public void ReturnCube(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);
    }

    private void ExpandPool()
    {
        Cube cube = Instantiate(_prefab);
        cube.Initialize(this);
        _pool.Enqueue(cube);
    }
}
