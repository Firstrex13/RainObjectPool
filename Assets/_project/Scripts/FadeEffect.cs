using System;
using System.Collections;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private float _maxAlfa = 1f;

    private Color _color;

    private Renderer _renderer;

    private Coroutine _destroy;

    public Action Disapeared;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
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

        float delay = 2f;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;

            float normalizedTime = elapsedTime  / delay;

            _color.a = Mathf.Lerp(alfa, 0, normalizedTime);

            _renderer.material.color = _color;

            yield return null;

        }

        Disapeared?.Invoke();
    }
}
