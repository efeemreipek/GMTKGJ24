using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HappinessManagerUI : MonoBehaviour
{
    public TextMeshProUGUI HappinessText;
    public Image HappinessImage;
    public Sprite HappyFace;
    public Sprite NormalFace;
    public Sprite SadFace;

    private void Awake()
    {
        HappinessManager.OnHappinessChanged += HappinessManager_OnHappinessChanged;
    }
    private void HappinessManager_OnHappinessChanged(int amount)
    {
        HappinessText.text = $"%{amount}";
        if (amount < 40) HappinessImage.sprite = SadFace;
        else if (amount >= 40 && amount < 65) HappinessImage.sprite = NormalFace;
        else HappinessImage.sprite = HappyFace;
    }
}
