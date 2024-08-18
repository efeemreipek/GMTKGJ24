using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventSO : ScriptableObject
{
    public Sprite EventIcon;
    [TextArea] public string EventText;
    public List<BarType> BarTypes;
    public int EventEffect;
    public bool isEventPositive;
}
