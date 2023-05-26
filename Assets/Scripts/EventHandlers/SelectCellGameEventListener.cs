using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCellGameEventListener : MonoBehaviour
{
    public SelectCellGameEventSO Event;
    public SelectCellEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(Vector2 value1,bool value2)
    { Response.Invoke(value1,value2); }
}