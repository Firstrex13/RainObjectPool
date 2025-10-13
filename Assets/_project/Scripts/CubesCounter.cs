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
        _cubeSpawner.Instantiated += IncreseCreatedCubesCount;
        _cubeSpawner.Activated += IncreaseActivatedCubes;
        _cubeSpawner.Activated += IncreaseSpawnedCubes;
        _cubeSpawner.Returned += DicreaseActivatedCubes;
    }

    private void OnDisable()
    {
        _cubeSpawner.Instantiated -= IncreseCreatedCubesCount;
        _cubeSpawner.Activated -= IncreaseActivatedCubes;
        _cubeSpawner.Activated -= IncreaseSpawnedCubes;
        _cubeSpawner.Returned -= DicreaseActivatedCubes;
    }

    private void Start()
    {
        _createdCubes = _cubeSpawner._cubesCount;
    }

    private void IncreseCreatedCubesCount()
    {
        _createdCubes = IncreseCreated(_createdCubes);
    }

    private void IncreaseActivatedCubes()
    {
        _activeCubes = IncreaseActivated(_activeCubes);
    }

    private void DicreaseActivatedCubes()
    {
        _activeCubes = DicreaseActivated(_activeCubes);
    }

    private void IncreaseSpawnedCubes()
    {
        _spawnedCubes = IncreaseSpawned(_spawnedCubes);
    }
}
