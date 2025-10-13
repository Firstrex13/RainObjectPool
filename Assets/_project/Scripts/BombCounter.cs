using UnityEngine;

public class BombCounter : CounterBasic
{
    [SerializeField] private BombSpawner _bombSpawner;

    [SerializeField] private int _spawnedBombs = 0;

    [SerializeField] private int _activeBombs = 0;

    [SerializeField] private int _createdBombs;

    public int SpawnedBombs => _spawnedBombs;
    public int ActiveBombs => _activeBombs;
    public int CreatedBombs => _createdBombs;

    private void OnEnable()
    {
        _bombSpawner.Activated += IncreaseActivatedBombs;
        _bombSpawner.Activated += IncreaseSpawnedBombs;
        _bombSpawner.Returned += DicreaseActivatedBombs;
        _bombSpawner.Instantiated += IncreseCreatedBombsCount;
    }

    private void OnDisable()
    {
        _bombSpawner.Activated -= IncreaseActivatedBombs;
        _bombSpawner.Activated -= IncreaseSpawnedBombs;
        _bombSpawner.Returned -= DicreaseActivatedBombs;
        _bombSpawner.Instantiated -= IncreseCreatedBombsCount;
    }

    private void Start()
    {
        _createdBombs = _bombSpawner._bombsCount;
    }

    private void IncreseCreatedBombsCount()
    {
        _createdBombs = IncreseCreated(_createdBombs);
    }

    private void IncreaseActivatedBombs()
    {
        _activeBombs = IncreaseActivated(_activeBombs);
    }

    private void DicreaseActivatedBombs()
    {
        _activeBombs = DicreaseActivated(_activeBombs);
    }

    private void IncreaseSpawnedBombs()
    {
        _spawnedBombs = IncreaseSpawned(_spawnedBombs);
    }
}
