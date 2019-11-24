﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public PoolObjectType poolObjectType;
    public float ScheduledOffTime;
    private Coroutine OffRoutine;

    private void OnEabled()
    {
        if (OffRoutine != null)
        {
            StopCoroutine(OffRoutine);
        }

        if (ScheduledOffTime > 0f)
        {
            OffRoutine = StartCoroutine(_ScheduledOff());
        }
    }

    public void TurnOff()
    {
        PoolManager.Instance.AddObject(this);
    }

    IEnumerator _ScheduledOff()
    {
        yield return new WaitForSeconds(ScheduledOffTime);

        if (!PoolManager.Instance.PoolDictionary[poolObjectType].Contains(this.gameObject))
        {
            TurnOff();
        }
    }
}
