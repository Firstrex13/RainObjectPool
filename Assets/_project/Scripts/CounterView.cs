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
        _cubesCounter.UpdatedInfo += UpdateSpawnedCubesCount;
        _bombsCounter.UpdatedInfo += UpdateSpawnedBombsCount;
        _cubesCounter.UpdatedInfo += UpdateActiveCubesCount;
        _bombsCounter.UpdatedInfo += UpdateActiveBombsCount;
        _cubesCounter.UpdatedInfo += UpdateCreatedCubesCount;
        _bombsCounter.UpdatedInfo += UpdateCreatedBombsCount;
    }

    private void OnDisable()
    {
        _cubesCounter.UpdatedInfo -= UpdateSpawnedCubesCount;
        _bombsCounter.UpdatedInfo -= UpdateSpawnedBombsCount;
        _cubesCounter.UpdatedInfo -= UpdateActiveCubesCount;
        _bombsCounter.UpdatedInfo -= UpdateActiveBombsCount;
        _cubesCounter.UpdatedInfo -= UpdateCreatedCubesCount;
        _bombsCounter.UpdatedInfo -= UpdateCreatedBombsCount;
    }

    private void UpdateSpawnedCubesCount()
    {
        UpdateInfo(_spawnedCubes, _cubesCounter.SpawnedCubes);
    }

    private void UpdateSpawnedBombsCount()
    {
        UpdateInfo(_spawnedBombs, _bombsCounter.SpawnedBombs);
    }

    private void UpdateActiveCubesCount()
    {
        UpdateInfo(_activeCubes, _cubesCounter.ActiveCubes);
    }

    private void UpdateActiveBombsCount()
    {
        UpdateInfo(_activeBombs, _bombsCounter.ActiveBombs);
    }

    private void UpdateCreatedCubesCount()
    {
        UpdateInfo(_createdCubes, _cubesCounter.CreatedCubes);
    }
    private void UpdateCreatedBombsCount()
    {
        UpdateInfo(_createdBombs, _bombsCounter.CreatedBombs);
    }

    private void UpdateInfo(TextMeshProUGUI text, int number)
    {
        text.text = number.ToString();
    }
}
