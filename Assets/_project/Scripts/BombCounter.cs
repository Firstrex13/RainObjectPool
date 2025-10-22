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

    private void Start()
    {
        _createdBombs = _bombSpawner.BombsStartCount;
    }

    public void OnIncreseCreatedBombsCount()
    {
        _createdBombs = IncreseCreated(_createdBombs);
    }

    public void OnIncreaseActivatedBombs()
    {
        _activeBombs = IncreaseActivated(_activeBombs);
    }

    public void OnDicreaseActivatedBombs()
    {
        _activeBombs = DicreaseActivated(_activeBombs);
    }

    public void OnIncreaseSpawnedBombs()
    {
        _spawnedBombs = IncreaseSpawned(_spawnedBombs);
    }
}
