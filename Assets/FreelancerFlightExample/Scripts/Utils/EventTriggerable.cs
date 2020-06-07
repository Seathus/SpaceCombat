using System.Collections;
using System.Collections.Generic;
using FLFlight;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EventTriggerable : MonoBehaviour
{
    public EventAction _eventToTrigger;
    public UnityEvent _event;

    public void TriggerEvent()
    {
        _eventToTrigger.Action(this.gameObject);
    }

    public KeyCode GetKeyToTrigger()
    {
        return _eventToTrigger._keyToTrigger;
    }
}
