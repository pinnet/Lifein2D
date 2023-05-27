using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreUpdateGameEventListener : MonoBehaviour
{
    public ScoreUpdateGameEventSO Event;
    public ScoreUpdateEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(int value)
    { Response.Invoke(value); }
}