using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private ObjectPool _pool;

    private bool _isTouched;

    private int _minDelay = 2;
    private int _maxDelay = 5;

    public void Initialize(ObjectPool pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        _isTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isTouched)
            {
                return;
            }

            _isTouched = true;

            StartCoroutine(DestroyWithDelay());
        }
    }

    private IEnumerator DestroyWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(Random.Range(_minDelay, _maxDelay));

        yield return delay;

        _pool.ReturnCube(this);
    }
}
