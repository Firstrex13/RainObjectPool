using System;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    protected int ObjectStartCount;

    public event Action Instantiated;

    protected void Created()
    {
        ObjectStartCount++;
        Instantiated?.Invoke();
    }
}
