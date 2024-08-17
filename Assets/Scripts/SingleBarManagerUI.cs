using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SingleBarManagerUI : MonoBehaviour
{
    public TextMeshProUGUI BudgetText;
    public TextMeshProUGUI GrowthText;
    public Color PositiveGrowthColor;
    public Color NegativeGrowthColor;

    private SingleBarManager singleBarManager;
    private int budget;
    private int growthRate;
    private Color growthRateColor;

    private void Awake()
    {
        singleBarManager = GetComponent<SingleBarManager>();

        SingleBarManager.OnBudgetChanged += SingleBarManager_OnBudgetChanged;
        SingleBarManager.OnGrowthRateChanged += SingleBarManager_OnGrowthRateChanged;
    }
    private void Start()
    {
        budget = singleBarManager.GetBudget();
        BudgetText.text = budget.ToString();

        growthRate = singleBarManager.GetGrowthRate();
        if (growthRate > 0) growthRateColor = PositiveGrowthColor;
        else growthRateColor = NegativeGrowthColor;

        GrowthText.text = $"%{growthRate.ToString()}";
        GrowthText.color = growthRateColor;
    }
    private void SingleBarManager_OnBudgetChanged(int amount)
    {
        budget = singleBarManager.GetBudget();
        BudgetText.text = budget.ToString();
    }
    private void SingleBarManager_OnGrowthRateChanged(int amount)
    {
        growthRate = singleBarManager.GetGrowthRate();
        if (growthRate > 0) growthRateColor = PositiveGrowthColor;
        else growthRateColor = NegativeGrowthColor;

        GrowthText.text = $"%{growthRate.ToString()}";
        GrowthText.color = growthRateColor;
    }
}
