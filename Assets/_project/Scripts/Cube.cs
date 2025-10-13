using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : DestroybleObject
{
    private Coroutine _destroyWithDelay;

    public bool IsTouched { get; private set; }

    public event Action<Cube> Died;

    private void OnEnable()
    {
        IsTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (IsTouched)
            {
                return;
            };

            IsTouched = true;

            if(_destroyWithDelay != null)
            {
                StopCoroutine(_destroyWithDelay);
            }

            StartCoroutine(DestroyWithDelay());
        }
    }

    private IEnumerator DestroyWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(Random.Range(MinDelay, MaxDelay));

        yield return delay;

        Died?.Invoke(this);   
    }
}
