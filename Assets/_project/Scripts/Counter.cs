using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _spawnedCubes = 0;
    [SerializeField] private int _spawnedBombs = 0;

    [SerializeField] private int _createdCubes = 0;
    [SerializeField] private int _createdBombs = 0;

    [SerializeField] private int _activeCubes = 0;

    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;


    private void Increase()
    {
        _spawnedCubes++;
    }
}
