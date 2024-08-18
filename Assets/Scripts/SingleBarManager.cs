using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarType
{
    Residential,
    Commercial,
    Industry,
    Education,
    CityServices,
    Offices,
    Agriculture
}

public class SingleBarManager : MonoBehaviour
{
    public static Action<int> OnBudgetChangedAmount;
    public static Action<int> OnBudgetChanged;
    public static Action<int> OnGrowthRateChanged;

    [SerializeField] private BarType type;
    [SerializeField] private int budget = 1000;
    [SerializeField] private int growthRate = 10;

    public int ChangingAmount = 100;
    public Image BarImage;

    private BarManager barManager;
    private int lastGrowthRate = 0;

    private void Awake()
    {
        barManager = GetComponentInParent<BarManager>();

        DayManager.OnDayPassed += DayManager_OnDayPassed;
    }
    private void DayManager_OnDayPassed(int dayCount)
    {
        HandleGrowthRate();
    }
    private void HandleGrowthRate()
    {
        int amountToAdd = budget * growthRate / 100;
        barManager.ChangeSpendableBudget(amountToAdd);
        OnBudgetChangedAmount?.Invoke(0);
    }
    public void PlusButton()
    {
        if(barManager.GetSpendableBudget() >= ChangingAmount)
        {
            AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab);

            budget += ChangingAmount;
            barManager.ChangeSpendableBudget(-ChangingAmount);
            OnBudgetChangedAmount?.Invoke(ChangingAmount);
            OnBudgetChanged?.Invoke(budget);
        }
    }
    public void MinusButton()
    {
        if(budget > 0)
        {
            AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab);

            budget -= ChangingAmount;
            barManager.ChangeSpendableBudget(ChangingAmount);
            OnBudgetChangedAmount?.Invoke(-ChangingAmount);
            OnBudgetChanged?.Invoke(budget);
        }
    }
    public void RandomizeGrowthRate()
    {
        int growthRateAddition;
        if(lastGrowthRate < 0)
        {
            growthRateAddition = UnityEngine.Random.Range(-2, 4);
            growthRate += growthRateAddition;
        }
        else
        {
            growthRateAddition = UnityEngine.Random.Range(-5, 5);
            growthRate += growthRateAddition;
        }
        lastGrowthRate = growthRateAddition;
        OnGrowthRateChanged?.Invoke(growthRate);
    }
    public int GetBudget() => budget;
    public int GetGrowthRate() => growthRate;
    public BarType GetBarType() => type;
    public void HandleEventEffect(int eventEffect)
    {
        growthRate += eventEffect;
        OnGrowthRateChanged?.Invoke(growthRate);
    }
}
