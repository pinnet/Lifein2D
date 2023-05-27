using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusUpdateGameEventListener : MonoBehaviour
{
    public StatusUpdateGameEventSO Event;
    public StatusUpdateEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(string value)
    { Response.Invoke(value); }
}