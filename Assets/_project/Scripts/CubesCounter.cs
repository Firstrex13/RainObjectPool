using UnityEngine;

public class CubesCounter : CounterBasic
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    [SerializeField] private int _spawnedCubes = 0;

    [SerializeField] private int _activeCubes = 0;

    [SerializeField] private int _createdCubes;

    public int SpawnedCubes => _spawnedCubes;

    public int ActiveCubes => _activeCubes;

    public int CreatedCubes => _createdCubes;

    private void OnEnable()
    {
        _cubeSpawner.Instantiated += OnIncreseCreatedCubesCount;
        _cubeSpawner.Activated += OnIncreaseActivatedCubes;
        _cubeSpawner.Activated += OnIncreaseSpawnedCubes;
        _cubeSpawner.Returned += OnDicreaseActivatedCubes;
    }

    private void OnDisable()
    {
        _cubeSpawner.Instantiated -= OnIncreseCreatedCubesCount;
        _cubeSpawner.Activated -= OnIncreaseActivatedCubes;
        _cubeSpawner.Activated -= OnIncreaseSpawnedCubes;
        _cubeSpawner.Returned -= OnDicreaseActivatedCubes;
    }

    private void Start()
    {
        _createdCubes = _cubeSpawner._cubesCount;
    }

    private void OnIncreseCreatedCubesCount()
    {
        _createdCubes = IncreseCreated(_createdCubes);
    }

    private void OnIncreaseActivatedCubes()
    {
        _activeCubes = IncreaseActivated(_activeCubes);
    }

    private void OnDicreaseActivatedCubes()
    {
        _activeCubes = DicreaseActivated(_activeCubes);
    }

    private void OnIncreaseSpawnedCubes()
    {
        _spawnedCubes = IncreaseSpawned(_spawnedCubes);
    }
}
