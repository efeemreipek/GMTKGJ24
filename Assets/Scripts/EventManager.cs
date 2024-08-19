using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject eventPrefab;
    [SerializeField, Range(0, 100)] private int eventOccurPercentage;
    [SerializeField] private List<EventSO> eventSOList = new List<EventSO>();

    private DayManager dayManager;

    private void Awake()
    {
        dayManager = GetComponent<DayManager>();

        DayManager.OnDayPassed += DayManager_OnDayPassed;
        Event.OnEventPopupClosed += Event_OnEventPopupClosed;
    }

    private void Event_OnEventPopupClosed(List<BarType> arg1, int arg2)
    {
        dayManager.PauseTime();
    }

    private void DayManager_OnDayPassed(int dayCount)
    {
        if(Random.Range(0, 100) <= eventOccurPercentage && !dayManager.GetIsGameOver() && dayManager.GetIsGameStarted())
        {
            dayManager.PauseTime();

            EventSO eventSO = eventSOList[Random.Range(0, eventSOList.Count)];

            GameObject eventGO = Instantiate(eventPrefab, transform).gameObject;
            Event _event = eventGO.GetComponent<Event>();
            _event.InitializeEvent(eventSO);
        }
    }
}
