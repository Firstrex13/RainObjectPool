using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    [SerializeField] private LayerMask _explosionLayer;

  //  [SerializeField] private FadeEffect _fadeEffect;

    private Coroutine _destroy;

    public Action<Bomb> Died;

    private void OnEnable()
    {
      
       // _fadeEffect.Disapeared += DestroyBomb;
    }

    private void OnDisable()
    {
  
        // _fadeEffect.Disapeared -= DestroyBomb;
    }

    private void Start()
    {
        DestroyBomb();
    }

    private void DestroyBomb()
    {
        if (_destroy != null)
        {
            StopCoroutine(_destroy);
        }

        _destroy = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        WaitForSeconds delay = new WaitForSeconds(Random.Range(2, 5));

        yield return delay;
        
        Explode();

        Died?.Invoke(this);
    }

    private void Explode()
    {
        foreach (var item in GetExplodableObjects())
        {
            item.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] colliders = new Collider[10];

        int count = Physics.OverlapSphereNonAlloc(transform.position, _explosionRadius, colliders, _explosionLayer);

        List<Rigidbody> objects = new();

        for (int i = 0; i < count; i++)
        {
            if (colliders[i].attachedRigidbody != null)
            {
                objects.Add(colliders[i].attachedRigidbody);
            }
        }

        return objects;
    }
}
