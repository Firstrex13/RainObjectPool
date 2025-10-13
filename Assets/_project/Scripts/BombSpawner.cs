using System;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;

    [SerializeField] private CubeSpawner _cubeSpawner;

    public int _bombsCount { get; private set; }

    private ObjectPool<Bomb> _pool;

    public event Action Activated;
    public event Action Returned;

    private void OnEnable()
    {
        _cubeSpawner.CubeReturned += CreateBomb;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeReturned -= CreateBomb;
    }

    private void Start()
    {
        _bombsCount = 5;

        _pool = new ObjectPool<Bomb>(_prefab, _bombsCount);
    }

    private void CreateBomb(Vector3 position)
    {
        Bomb bomb;

        bomb = _pool.GetFromPool();

        Activated?.Invoke();

        bomb.transform.position = position;

        bomb.Died += ReturnToPool;
    }

    private void ReturnToPool(Bomb bomb)
    {
        _pool.ReturnObject(bomb);

        bomb.Died -= ReturnToPool;

        Returned?.Invoke();
    }
}
