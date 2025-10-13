using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    [SerializeField] private int _spawnedCubes = 0;
    [SerializeField] private int _spawnedBombs = 0;

    [SerializeField] private int _activeCubes = 0;
    [SerializeField] private int _activeBombs = 0;


    [SerializeField] private int _createdCubes;
    [SerializeField] private int _createdBombs;


    private void OnEnable()
    {
        _cubeSpawner.Activated += IncreaseActivatedCubes;
        _cubeSpawner.Activated += IncreaseSpawnedCubes;
        _cubeSpawner.Returned += DicreaseActivatedCubes;
        _bombSpawner.Activated += IncreaseActivatedBombs;
        _bombSpawner.Activated += IncreaseSpawnedBombs;
        _bombSpawner.Returned += DicreaseActivatedBombs;

    }

    private void OnDisable()
    {
        _cubeSpawner.Activated -= IncreaseActivatedCubes;
        _cubeSpawner.Activated -= IncreaseSpawnedCubes;
        _cubeSpawner.Returned -= DicreaseActivatedCubes;
        _bombSpawner.Activated -= IncreaseActivatedBombs;
        _bombSpawner.Activated -= IncreaseSpawnedBombs;
        _bombSpawner.Returned -= DicreaseActivatedBombs;
    }

    private void Start()
    {
        _createdCubes = _cubeSpawner._cubesCount;
        _createdBombs = _bombSpawner._bombsCount;
    }

    private void IncreaseActivatedCubes()
    {
        IncreaseNumber(ref _activeCubes);
    }

    private void DicreaseActivatedCubes()
    {
        DicreaseNumber(ref _activeCubes);
    }

    private void IncreaseActivatedBombs()
    {
        IncreaseNumber(ref _activeBombs);
    }

    private void DicreaseActivatedBombs()
    {
        DicreaseNumber(ref _activeBombs);
    }

    private void IncreaseSpawnedCubes()
    {
        IncreaseNumber(ref _spawnedCubes);
    }

    private void IncreaseSpawnedBombs()
    {
        IncreaseNumber(ref _spawnedBombs);
    }

    private void IncreseCreatedCubesCount()
    {
        IncreaseNumber(ref _createdCubes);
    }

    private void IncreseCreatedBombsCount()
    {
        IncreaseNumber(ref _createdBombs);
    }

    private void IncreaseNumber(ref int number)
    {
        number++;
    }

    private void DicreaseNumber(ref int number)
    {
        number--;
    }
}
