using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    [SerializeField] private Vector3 _position;

    [SerializeField] private float _spawnDelay = 1f;

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        var delay = new WaitForSeconds(_spawnDelay);

        while (enabled)
        {
            yield return delay;

            Vector3 randomPosition = _position + new Vector3(Random.Range(-8, 8), 0, Random.Range(-6, 0));

            Cube cube = _pool.GetFromPool();

            cube.transform.position = randomPosition;
        }
    }
}
