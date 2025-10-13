using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : BaseSpawner
{
    [SerializeField] private Cube _prefab;

    [SerializeField] private Vector3 _position;

    [SerializeField] private float _spawnDelay = 1f;

    private ObjectPool<Cube> _pool;

    private Coroutine _spawnCubes;

    public event Action Activated;
    public event Action Returned;

    public event Action<Vector3> CubeReturned;

    public int CubesStartCount => ObjectStartCount;

    private void OnDisable()
    {
        _pool.Instantiated -= OnCubeInstatntiated;
    }

    private void Start()
    {
        ObjectStartCount = 5;

        _pool = new ObjectPool<Cube>(_prefab, ObjectStartCount);

        _pool.Instantiated += OnCubeInstatntiated;

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

            Activated?.Invoke();

            cube.transform.position = randomPosition;

            cube.Died += ReturnToPool;

            yield return delay;
        }
    }

    private void ReturnToPool(Cube cube)
    {
        _pool.ReturnObject(cube);

        cube.Died -= ReturnToPool;

        CubeReturned?.Invoke(cube.transform.position);

        Returned?.Invoke();
    }

    private void OnCubeInstatntiated()
    {
        Created();
    }
}
