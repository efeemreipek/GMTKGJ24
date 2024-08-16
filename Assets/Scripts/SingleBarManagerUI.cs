using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SingleBarManagerUI : MonoBehaviour
{
    public TextMeshProUGUI BudgetText;

    private SingleBarManager singleBarManager;
    private int budget;

    private void Awake()
    {
        singleBarManager = GetComponent<SingleBarManager>();

        SingleBarManager.OnBudgetChanged += SingleBarManager_OnBudgetChanged;
    }
    private void Start()
    {
        budget = singleBarManager.GetBudget();
        BudgetText.text = budget.ToString();
    }
    private void SingleBarManager_OnBudgetChanged(int amount)
    {
        budget = singleBarManager.GetBudget();
        BudgetText.text = budget.ToString();
    }
}
