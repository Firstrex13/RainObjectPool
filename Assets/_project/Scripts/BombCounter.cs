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
        _bombSpawner.Activated += OnIncreaseActivatedBombs;
        _bombSpawner.Activated += OnIncreaseSpawnedBombs;
        _bombSpawner.Returned += OnDicreaseActivatedBombs;
        _bombSpawner.Instantiated += OnIncreseCreatedBombsCount;
    }

    private void OnDisable()
    {
        _bombSpawner.Activated -= OnIncreaseActivatedBombs;
        _bombSpawner.Activated -= OnIncreaseSpawnedBombs;
        _bombSpawner.Returned -= OnDicreaseActivatedBombs;
        _bombSpawner.Instantiated -= OnIncreseCreatedBombsCount;
    }

    private void Start()
    {
        _createdBombs = _bombSpawner.BombsStartCount;
    }

    private void OnIncreseCreatedBombsCount()
    {
        _createdBombs = IncreseCreated(_createdBombs);
    }

    private void OnIncreaseActivatedBombs()
    {
        _activeBombs = IncreaseActivated(_activeBombs);
    }

    private void OnDicreaseActivatedBombs()
    {
        _activeBombs = DicreaseActivated(_activeBombs);
    }

    private void OnIncreaseSpawnedBombs()
    {
        _spawnedBombs = IncreaseSpawned(_spawnedBombs);
    }
}
