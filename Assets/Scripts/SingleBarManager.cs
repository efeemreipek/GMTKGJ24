using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleBarManager : MonoBehaviour
{
    public static Action<int> OnBudgetChangedAmount;
    public static Action<int> OnBudgetChanged;

    [SerializeField] private int budget = 1000;

    public int ChangingAmount = 100;
    public Image BarImage;

    private BarManager barManager;


    private void Awake()
    {
        barManager = GetComponentInParent<BarManager>();
    }
    public void PlusButton()
    {
        budget += ChangingAmount;
        OnBudgetChangedAmount?.Invoke(ChangingAmount);
        OnBudgetChanged?.Invoke(budget);
    }
    public void MinusButton()
    {
        if(budget > 0)
        {
            budget -= ChangingAmount;
            OnBudgetChangedAmount?.Invoke(-ChangingAmount);
            OnBudgetChanged?.Invoke(budget);
        }
    }
    public int GetBudget() => budget;
}
