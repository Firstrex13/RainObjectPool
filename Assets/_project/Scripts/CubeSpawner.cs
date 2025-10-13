using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    [SerializeField] private Vector3 _position;

    [SerializeField] private float _spawnDelay = 1f;

    public int _cubesCount { get; private set; }

    private ObjectPool<Cube> _pool;

    public event Action Activated;
    public event Action Returned;
    public event Action<Vector3> CubeReturned;

    private void Start()
    {
        _cubesCount = 1;

        _pool = new ObjectPool<Cube>(_prefab, _cubesCount);

        _pool.Instantiated += OnCubeInstatntiated;

        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
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
        _cubesCount++;
    }
}
