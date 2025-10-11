using System;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    [SerializeField] private LayerMask _explosionLayer;

    [SerializeField] private FadeEffect _fadeEffect;

    public event Action<Bomb> Died;

    private void OnEnable()
    {

        _fadeEffect.Disapeared += Destroy;
    }

    private void OnDisable()
    {

        _fadeEffect.Disapeared -= Destroy;
    }

    private void Destroy()
    {
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
