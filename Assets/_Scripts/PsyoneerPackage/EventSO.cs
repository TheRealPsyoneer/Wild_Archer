using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Event", menuName = "Event SO")]
public class EventSO : ScriptableObject
{
    public event Action ThingHappened;

    public void Broadcast()
    {
        ThingHappened?.Invoke();
    }
}
