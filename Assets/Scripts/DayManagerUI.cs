using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DayManagerUI : MonoBehaviour
{
    public TextMeshProUGUI DayText;
    public Image SlowDownImage;
    public Image PauseImage;
    public Image NormalImage;
    public Image SpeedUpImage;
    public Image DayProgressImage;
    public Color ActiveImageColor;
    public Color DeactiveImageColor;

    private DayManager dayManager;

    private void Awake()
    {
        dayManager = GetComponent<DayManager>();

        DayManager.OnDayPassed += DayManager_OnDayPassed;
    }
    private void Update()
    {
        DayProgressImage.fillAmount = dayManager.GetDayTimer() / dayManager.GetDayThreshold();
    }
    private void DayManager_OnDayPassed(int amount)
    {
        //DayText.text = $"DAY {amount.ToString()}";
        ChangeDayText(amount.ToString());
    }
    public void ChangeDayText(string text)
    {
        DayText.text = $"DAY {text}";
    }
    public void ActivateOrDeactivateImage(Image image, bool cond)
    {
        if (cond)
        {
            image.color = ActiveImageColor;
        }
        else
        {
            image.color = DeactiveImageColor;
        }
    }
}
