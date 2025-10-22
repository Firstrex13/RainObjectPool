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

    private void Start()
    {
        _createdCubes = _cubeSpawner.CubesStartCount;
    }

    public void OnIncreseCreatedCubesCount()
    {
        _createdCubes = IncreseCreated(_createdCubes);
    }

    public void OnIncreaseActivatedCubes()
    {
        _activeCubes = IncreaseActivated(_activeCubes);
    }

    public void OnDicreaseActivatedCubes()
    {
        _activeCubes = DicreaseActivated(_activeCubes);
    }

    public void OnIncreaseSpawnedCubes()
    {
        _spawnedCubes = IncreaseSpawned(_spawnedCubes);
    }
}
