using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Bomb : DestroybleObject
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    [SerializeField] private LayerMask _explosionLayer;

    private float _fadeSpeed = 0.2f;

    private float _maxAlfa = 1f;

    private Color _color;

    private Renderer _renderer;

    private Coroutine _destroy;

    public Action<Bomb> Died;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        _color.a = _maxAlfa;

        _renderer.material.color = _color;

        if (_destroy != null)
        {
            StopCoroutine(_destroy);
        }

        _destroy = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        _color = _renderer.material.color;

        float alfa = _color.a;

        float elapsedTime = 0f;

        float delay = Random.Range(MinDelay, MaxDelay);

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;

            float normalizedTime = (elapsedTime * _fadeSpeed) / delay;

            _color.a = Mathf.Lerp(alfa, 0, normalizedTime);

            _renderer.material.color = _color;

            yield return null;
        }

        _color.a = 0;

        _renderer.material.color = _color;

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
