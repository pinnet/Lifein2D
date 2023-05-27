using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridInitGameEventListener : MonoBehaviour
{
    public GridInitGameEventSO Event;
    public GridInitEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised(int width,int height,float cellSize)
    { Response.Invoke(width,height,cellSize); }
}