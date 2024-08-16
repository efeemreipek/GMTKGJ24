using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BarManagerUI : MonoBehaviour
{
    public TextMeshProUGUI TotalBudgetText;

    private BarManager barManager;

    private void Awake()
    {
        barManager = GetComponent<BarManager>();

        BarManager.OnTotalBudgetChanged += BarManager_OnTotalBudgetChanged;
    }

    private void Start()
    {
        TotalBudgetText.text = barManager.GetTotalBudget().ToString();
    }

    private void BarManager_OnTotalBudgetChanged(int amount)
    {
        TotalBudgetText.text = amount.ToString();
    }
}
