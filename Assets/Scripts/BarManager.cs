using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public static Action<int> OnTotalBudgetChanged;
    public static Action<int> OnSpendableBudgetChanged;

    [SerializeField] private int totalBudget;
    [SerializeField] private int spendableBudget = 1000;

    private List<SingleBarManager> barList = new List<SingleBarManager>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            barList.Add(transform.GetChild(i).GetComponent<SingleBarManager>());
            totalBudget += barList[i].GetBudget();
        }

        SingleBarManager.OnBudgetChangedAmount += SingleBarManager_OnBudgetChangedAmount;
        DayManager.OnDayPassed += DayManager_OnDayPassed;
        Event.OnEventPopupClosed += Event_OnEventPopupClosed;
    }
    private void Event_OnEventPopupClosed(List<BarType> barTypes, int eventEffect)
    {
        foreach (SingleBarManager bar in barList)
        {
            if (barTypes.Contains(bar.GetBarType()))
            {
                bar.HandleEventEffect(eventEffect);
            }
        }
    }
    private void DayManager_OnDayPassed(int dayCount)
    {
        foreach (SingleBarManager bar in barList)
        {
            bar.RandomizeGrowthRate();
        }
    }
    private void SingleBarManager_OnBudgetChangedAmount(int amount)
    {
        totalBudget += amount;
        OnTotalBudgetChanged?.Invoke(totalBudget);
        OnSpendableBudgetChanged?.Invoke(spendableBudget);
        foreach (SingleBarManager bar in barList)
        {
            bar.BarImage.fillAmount = (float)bar.GetBudget() / totalBudget;
        }
    }
    public int GetTotalBudget() => totalBudget;
    public int GetSpendableBudget() => spendableBudget;
    public void ChangeSpendableBudget(int amount) => spendableBudget += amount;
    public List<SingleBarManager> GetSingleBarList() => barList;
}
