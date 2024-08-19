using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessManager : MonoBehaviour
{
    public static Action<int> OnHappinessChanged;
    public static Action OnHappinessZero;
    public static Action OnHappinessFull;

    [SerializeField] private int happiness = 50;

    private BarManager barManager;
    private List<SingleBarManager> barList;

    private void Awake()
    {
        happiness = 50;

        barManager = GetComponent<BarManager>();

        DayManager.OnDayPassed += DayManager_OnDayPassed;
        MenuManager.OnGameRestarted += MenuManager_OnGameRestarted;
    }
    private void Start()
    {
        barList = barManager.GetSingleBarList();

        OnHappinessChanged?.Invoke(happiness);
    }
    private void MenuManager_OnGameRestarted()
    {
        happiness = 50;
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

        if (happiness <= 0)
        {
            happiness = 0;
            OnHappinessZero?.Invoke();
        }
        else if (happiness >= 100)
        {
            happiness = 100;
            OnHappinessFull?.Invoke();
        }

        OnHappinessChanged?.Invoke(happiness);
    }
}
