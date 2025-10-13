using System;
using UnityEngine;

public class CounterBasic : MonoBehaviour
{
    protected int ActivatedCount = 0;

    public event Action UpdatedInfo;

    protected int IncreaseActivated(int count)
    {
        ActivatedCount = IncreaseNumber(count);

        UpdatedInfo?.Invoke();

        return ActivatedCount;
    }

    protected int DicreaseActivated(int count)
    {
        ActivatedCount =  DicreaseNumber(count);

        UpdatedInfo?.Invoke();

        return ActivatedCount;
    }

    protected int IncreaseSpawned(int count)
    {
        int spawnedNumber = IncreaseNumber(count);

        UpdatedInfo?.Invoke();

        return spawnedNumber;
    }

    protected int IncreseCreated(int count)
    {
        int createdNumber = IncreaseNumber(count);

        UpdatedInfo?.Invoke();

        return createdNumber;
    }

    protected int IncreaseNumber(int number)
    {
        number++;

        return number;
    }

    protected int DicreaseNumber(int number)
    {
        number--;

        return number;
    }
}
