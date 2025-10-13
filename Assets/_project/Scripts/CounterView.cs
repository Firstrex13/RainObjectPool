using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private CubesCounter _cubesCounter;
    [SerializeField] private BombCounter _bombsCounter;

    [SerializeField] private TextMeshProUGUI _spawnedCubes;
    [SerializeField] private TextMeshProUGUI _spawnedBombs;
    [SerializeField] private TextMeshProUGUI _activeCubes;
    [SerializeField] private TextMeshProUGUI _activeBombs;
    [SerializeField] private TextMeshProUGUI _createdCubes;
    [SerializeField] private TextMeshProUGUI _createdBombs;

    private void OnEnable()
    {
        _cubesCounter.UpdatedInfo += OnUpdateSpawnedCubesCount;
        _bombsCounter.UpdatedInfo += OnUpdateSpawnedBombsCount;
        _cubesCounter.UpdatedInfo += OnUpdateActiveCubesCount;
        _bombsCounter.UpdatedInfo += OnUpdateActiveBombsCount;
        _cubesCounter.UpdatedInfo += OnUpdateCreatedCubesCount;
        _bombsCounter.UpdatedInfo += OnUpdateCreatedBombsCount;
    }

    private void OnDisable()
    {
        _cubesCounter.UpdatedInfo -= OnUpdateSpawnedCubesCount;
        _bombsCounter.UpdatedInfo -= OnUpdateSpawnedBombsCount;
        _cubesCounter.UpdatedInfo -= OnUpdateActiveCubesCount;
        _bombsCounter.UpdatedInfo -= OnUpdateActiveBombsCount;
        _cubesCounter.UpdatedInfo -= OnUpdateCreatedCubesCount;
        _bombsCounter.UpdatedInfo -= OnUpdateCreatedBombsCount;
    }

    private void OnUpdateSpawnedCubesCount()
    {
        UpdateInfo(_spawnedCubes, _cubesCounter.SpawnedCubes);
    }

    private void OnUpdateSpawnedBombsCount()
    {
        UpdateInfo(_spawnedBombs, _bombsCounter.SpawnedBombs);
    }

    private void OnUpdateActiveCubesCount()
    {
        UpdateInfo(_activeCubes, _cubesCounter.ActiveCubes);
    }

    private void OnUpdateActiveBombsCount()
    {
        UpdateInfo(_activeBombs, _bombsCounter.ActiveBombs);
    }

    private void OnUpdateCreatedCubesCount()
    {
        UpdateInfo(_createdCubes, _cubesCounter.CreatedCubes);
    }
    private void OnUpdateCreatedBombsCount()
    {
        UpdateInfo(_createdBombs, _bombsCounter.CreatedBombs);
    }

    private void UpdateInfo(TextMeshProUGUI text, int number)
    {
        text.text = number.ToString();
    }
}
