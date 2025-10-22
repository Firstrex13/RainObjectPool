using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : BaseSpawner<Cube>
{
    [SerializeField] private CubesCounter _cubesCounter;
    [SerializeField] private Cube _prefab;

    [SerializeField] private Vector3 _position;

    [SerializeField] private float _spawnDelay = 1f;

    private Coroutine _spawnCubes;

    public event Action<Vector3> CubeReturned;

    public int CubesStartCount => ObjectStartCount;

    private void Awake()
    {
        ObjectStartCount = 5;

        _pool = new ObjectPool<Cube>(_prefab, ObjectStartCount);

        _pool.Instantiated += OnCubeInstatntiated;
    }

    private void OnEnable()
    {
        _pool.Instantiated += _cubesCounter.OnIncreseCreatedCubesCount;
        _pool.Activated += _cubesCounter.OnIncreaseActivatedCubes;
        _pool.Activated += _cubesCounter.OnIncreaseSpawnedCubes;
        _pool.Returned += _cubesCounter.OnDicreaseActivatedCubes;
    }
    private void OnDisable()
    {
        _pool.Instantiated -= OnCubeInstatntiated;
        _pool.Activated -= _cubesCounter.OnIncreaseActivatedCubes;
        _pool.Returned -= _cubesCounter.OnDicreaseActivatedCubes;
        _pool.Activated -= _cubesCounter.OnIncreaseSpawnedCubes;
    }

    private void Start()
    {
        if (_spawnCubes != null)
        {
            StopCoroutine(_spawnCubes);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        Cube cube;

        while (enabled)
        {
            Vector3 randomPosition = _position + new Vector3(Random.Range(-8, 8), 0, Random.Range(-6, 0));

            cube = _pool.GetFromPool();

            cube.transform.position = randomPosition;

            cube.Died += OnReturnToPool;

            yield return delay;
        }
    }

    protected override void OnReturnToPool(Cube cube)
    {
        base.OnReturnToPool(cube);

        cube.Died -= OnReturnToPool;

        CubeReturned?.Invoke(cube.transform.position);
    }

    private void OnCubeInstatntiated()
    {
        Created();
    }
}
