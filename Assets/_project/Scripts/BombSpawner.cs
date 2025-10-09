using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Bomb _prefab;

    [SerializeField] private CubeSpawner _cubeSpawner;

    private ObjectPool<Bomb> _pool;

    private void OnEnable()
    {
        _cubeSpawner.CubeReturned += CreateBomb;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeReturned -= CreateBomb;
    }

    private void Start()
    {
        _pool = new ObjectPool<Bomb>(_prefab);
    }

    private void CreateBomb(Vector3 position)
    {
        Bomb bomb;

        bomb = _pool.GetFromPool();

        bomb.transform.position = position;

        bomb.Died += ReturnToPool;
    }

    private void ReturnToPool(Bomb bomb)
    {
        _pool.ReturnCube(bomb);

        bomb.Died -= ReturnToPool;
    }
}
