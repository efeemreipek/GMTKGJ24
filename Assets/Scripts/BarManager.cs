using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public static Action<int> OnTotalBudgetChanged;

    [SerializeField] private int totalBudget;

    private List<SingleBarManager> barList = new List<SingleBarManager>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            barList.Add(transform.GetChild(i).GetComponent<SingleBarManager>());
            totalBudget += barList[i].GetBudget();
        }

        SingleBarManager.OnBudgetChangedAmount += SingleBarManager_OnBudgetChangedAmount;
    }

    private void SingleBarManager_OnBudgetChangedAmount(int amount)
    {
        totalBudget += amount;
        OnTotalBudgetChanged?.Invoke(totalBudget);
        foreach (SingleBarManager bar in barList)
        {
            bar.BarImage.fillAmount = (float)bar.GetBudget() / totalBudget;
        }
    }
    public int GetTotalBudget() => totalBudget;
}
