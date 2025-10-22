using UnityEngine;

public class BombSpawner : BaseSpawner<Bomb>
{
    [SerializeField] private BombCounter _bombCounter;

    [SerializeField] private Bomb _prefab;

    [SerializeField] private CubeSpawner _cubeSpawner;

    public int BombsStartCount => ObjectStartCount;

    private void Awake()
    {
        ObjectStartCount = 5;

        _pool = new ObjectPool<Bomb>(_prefab, ObjectStartCount);

        _pool.Instantiated += OnBombInstatntiated;
    }

    private void OnEnable()
    {
        _cubeSpawner.CubeReturned += OnCreateBomb;

        _pool.Instantiated += _bombCounter.OnIncreseCreatedBombsCount;
        _pool.Activated += _bombCounter.OnIncreaseActivatedBombs;
        _pool.Activated += _bombCounter.OnIncreaseSpawnedBombs;
        _pool.Returned += _bombCounter.OnDicreaseActivatedBombs;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeReturned -= OnCreateBomb;
        _pool.Instantiated -= OnBombInstatntiated;

        _pool.Instantiated -= _bombCounter.OnIncreseCreatedBombsCount;
        _pool.Activated -= _bombCounter.OnIncreaseActivatedBombs;
        _pool.Activated -= _bombCounter.OnIncreaseSpawnedBombs;
        _pool.Returned -= _bombCounter.OnDicreaseActivatedBombs;
    }

    private void OnCreateBomb(Vector3 position)
    {
        Bomb bomb;

        bomb = _pool.GetFromPool();

        bomb.transform.position = position;

        bomb.Died += OnReturnToPool;
    }

    protected override void OnReturnToPool(Bomb bomb)
    {
        base._pool.ReturnObject(bomb);

        bomb.Died -= OnReturnToPool;
    }

    private void OnBombInstatntiated()
    {
        Created();
    }
}
