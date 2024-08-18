using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessManager : MonoBehaviour
{
    public static Action<int> OnHappinessChanged;

    [SerializeField] private int happiness = 50;

    private BarManager barManager;
    private List<SingleBarManager> barList;

    private void Awake()
    {
        barManager = GetComponent<BarManager>();

        DayManager.OnDayPassed += DayManager_OnDayPassed;
    }
    private void Start()
    {
        barList = barManager.GetSingleBarList();

        OnHappinessChanged?.Invoke(happiness);
    }
    private void DayManager_OnDayPassed(int dayCount)
    {
        HandleHappiness();
    }
    private void HandleHappiness()
    {
        int averageBudgetOnBars = barManager.GetTotalBudget() / barList.Count;

        foreach(var bar in barList)
        {
            if(bar.GetBudget() <= averageBudgetOnBars)
            {
                if(bar.GetBudget() <= 1000)
                {
                    happiness--;
                }
                happiness--;
            }
            else
            {
                happiness++;
            }
        }

        if(happiness < 0) happiness = 0;
        else if(happiness > 100) happiness = 100;

        OnHappinessChanged?.Invoke(happiness);
    }
}
