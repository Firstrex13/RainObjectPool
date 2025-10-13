using System;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;

    [SerializeField] private CubeSpawner _cubeSpawner;

    public int _bombsStartCount { get; private set; }

    private ObjectPool<Bomb> _pool;

    public event Action Activated;
    public event Action Returned;
    public event Action Instantiated;

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
        _bombsStartCount = 5;

        _pool = new ObjectPool<Bomb>(_prefab, _bombsStartCount);

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
        _bombsStartCount++;
        Instantiated?.Invoke();
    }
}
