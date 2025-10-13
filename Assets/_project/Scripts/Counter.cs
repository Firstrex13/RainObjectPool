using System;
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

    public int SpawnedCubes => _spawnedCubes;
    public int SpawnedBombs => _spawnedBombs;
    public int ActiveCubes => _activeCubes;
    public int ActiveBombs => _activeBombs;
    public int CreatedCubes => _createdCubes;
    public int CreatedBombs => _createdBombs;

    public event Action UpdatedInfo;


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

    private void Update()
    {
        _createdCubes = _cubeSpawner._cubesCount;
        _createdBombs = _bombSpawner._bombsCount;
    }

    private void IncreaseActivatedCubes()
    {
        IncreaseNumber(ref _activeCubes);

        UpdatedInfo?.Invoke();
    }

    private void DicreaseActivatedCubes()
    {
        DicreaseNumber(ref _activeCubes);

        UpdatedInfo?.Invoke();
    }

    private void IncreaseActivatedBombs()
    {
        IncreaseNumber(ref _activeBombs);

        UpdatedInfo?.Invoke();
    }

    private void DicreaseActivatedBombs()
    {
        DicreaseNumber(ref _activeBombs);

        UpdatedInfo?.Invoke();
    }

    private void IncreaseSpawnedCubes()
    {
        IncreaseNumber(ref _spawnedCubes);

        UpdatedInfo?.Invoke();
    }

    private void IncreaseSpawnedBombs()
    {
        IncreaseNumber(ref _spawnedBombs);

        UpdatedInfo?.Invoke();
    }

    private void IncreseCreatedCubesCount()
    {
        IncreaseNumber(ref _createdCubes);

        UpdatedInfo?.Invoke();
    }

    private void IncreseCreatedBombsCount()
    {
        IncreaseNumber(ref _createdBombs);

        UpdatedInfo?.Invoke();
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
