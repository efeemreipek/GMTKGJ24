using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static Action<int> OnDayPassed;

    [SerializeField] private float dayThreshold = 15f;

    private float dayTimer = 0f;
    private int dayCount = 0;

    private void Update()
    {
        print(dayTimer);
        dayTimer += Time.deltaTime;

        if(dayTimer >= dayThreshold)
        {
            dayTimer = 0f;
            OnDayPassed?.Invoke(++dayCount);
        }
    }
}
