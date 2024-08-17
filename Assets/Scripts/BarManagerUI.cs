using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BarManagerUI : MonoBehaviour
{
    public TextMeshProUGUI TotalBudgetText;
    public TextMeshProUGUI SpendableBudgetText;

    private BarManager barManager;

    private void Awake()
    {
        barManager = GetComponent<BarManager>();

        BarManager.OnTotalBudgetChanged += BarManager_OnTotalBudgetChanged;
        BarManager.OnSpendableBudgetChanged += BarManager_OnSpendableBudgetChanged;
    }
    private void Start()
    {
        TotalBudgetText.text = barManager.GetTotalBudget().ToString();
        SpendableBudgetText.text = barManager.GetSpendableBudget().ToString();
    }
    private void BarManager_OnTotalBudgetChanged(int amount)
    {
        TotalBudgetText.text = amount.ToString();
    }
    private void BarManager_OnSpendableBudgetChanged(int amount)
    {
        SpendableBudgetText.text = barManager.GetSpendableBudget().ToString();
    }
}
