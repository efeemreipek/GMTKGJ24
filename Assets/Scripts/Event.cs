using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public static Action<List<BarType>, int> OnEventPopupClosed;

    private EventSO eventSO;
    private EventUI eventUI;

    private void Awake()
    {
        eventUI = GetComponent<EventUI>();
    }
    public void InitializeEvent(EventSO eventSO)
    {
        this.eventSO = eventSO;

        if(eventSO.isEventPositive) AudioManager.Instance.CreateAudioGO(AudioManager.Instance.PositiveEventAudioPrefab);
        else AudioManager.Instance.CreateAudioGO(AudioManager.Instance.NegativeEventAudioPrefab);

        eventUI.EventIcon.sprite = eventSO.EventIcon;
        eventUI.EventText.text = eventSO.EventText;
    }
    public void ClosePopup()
    {
        AudioManager.Instance.CreateAudioGO(AudioManager.Instance.ButtonClickAudioPrefab);

        OnEventPopupClosed?.Invoke(eventSO.BarTypes, eventSO.EventEffect);
        Destroy(gameObject);
    }
}
