using System;
using UnityEngine;

public class BombSpawner : BaseSpawner
{
    [SerializeField] private Bomb _prefab;

    [SerializeField] private CubeSpawner _cubeSpawner;

    private ObjectPool<Bomb> _pool;

    public event Action Activated;
    public event Action Returned;

    public int BombsStartCount => ObjectStartCount;

    private void OnEnable()
    {
        _cubeSpawner.CubeReturned += OnCreateBomb;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeReturned -= OnCreateBomb;
        _pool.Instantiated -= OnBombInstatntiated;
    }

    private void Start()
    {
        ObjectStartCount = 5;

        _pool = new ObjectPool<Bomb>(_prefab, ObjectStartCount);

        _pool.Instantiated += OnBombInstatntiated;
    }

    private void OnCreateBomb(Vector3 position)
    {
        Bomb bomb;

        bomb = _pool.GetFromPool();

        Activated?.Invoke();

        bomb.transform.position = position;

        bomb.Died += OnReturnToPool;
    }

    private void OnReturnToPool(Bomb bomb)
    {
        _pool.ReturnObject(bomb);

        bomb.Died -= OnReturnToPool;

        Returned?.Invoke();
    }

    private void OnBombInstatntiated()
    {
        Created();
    }
}
