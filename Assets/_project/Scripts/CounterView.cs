using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    [SerializeField] private TextMeshProUGUI _spawnedCubes;
    [SerializeField] private TextMeshProUGUI _spawnedBombs;
    [SerializeField] private TextMeshProUGUI _activeCubes;
    [SerializeField] private TextMeshProUGUI _activeBombs;
    [SerializeField] private TextMeshProUGUI _createdCubes;
    [SerializeField] private TextMeshProUGUI _createdBombs;

    private void OnEnable()
    {
        _counter.UpdatedInfo += UpdateSpawnedCubesCount;
        _counter.UpdatedInfo += UpdateSpawnedBombsCount;
        _counter.UpdatedInfo += UpdateActiveCubesCount;
        _counter.UpdatedInfo += UpdateActiveBombsCount;
        _counter.UpdatedInfo += UpdateCreatedCubesCount;
        _counter.UpdatedInfo += UpdateCreatedBombsCount;
    }

    private void OnDisable()
    {
        _counter.UpdatedInfo -= UpdateSpawnedCubesCount;
        _counter.UpdatedInfo -= UpdateSpawnedBombsCount;
        _counter.UpdatedInfo -= UpdateActiveCubesCount;
        _counter.UpdatedInfo -= UpdateActiveBombsCount;
        _counter.UpdatedInfo -= UpdateCreatedCubesCount;
        _counter.UpdatedInfo -= UpdateCreatedBombsCount;
    }

    private void UpdateSpawnedCubesCount()
    {
        UpdateInfo(_spawnedCubes, _counter.SpawnedCubes);
    }

    private void UpdateSpawnedBombsCount()
    {
        UpdateInfo(_spawnedBombs, _counter.SpawnedBombs);
    }

    private void UpdateActiveCubesCount()
    {
        UpdateInfo(_activeCubes, _counter.ActiveCubes);
    }

    private void UpdateActiveBombsCount()
    {
        UpdateInfo(_activeBombs, _counter.ActiveBombs);
    }

    private void UpdateCreatedCubesCount()
    {
        UpdateInfo(_createdCubes, _counter.CreatedCubes);
    }
    private void UpdateCreatedBombsCount()
    {
        UpdateInfo(_createdBombs, _counter.CreatedBombs);
    }

    private void UpdateInfo(TextMeshProUGUI text, int number)
    {
        text.text = number.ToString();
    }
}
