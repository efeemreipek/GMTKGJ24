using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DayManagerUI : MonoBehaviour
{
    public TextMeshProUGUI DayText;

    private void Awake()
    {
        DayManager.OnDayPassed += DayManager_OnDayPassed;
    }

    private void DayManager_OnDayPassed(int amount)
    {
        DayText.text = $"DAY {amount.ToString()}";
    }
}
