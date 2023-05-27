using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Events/Update Status Event"), System.Serializable]
public class StatusUpdateGameEventSO : ScriptableObject
{
    private List<StatusUpdateGameEventListener> listeners =
        new List<StatusUpdateGameEventListener>();
    public void Raise(string value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(StatusUpdateGameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(StatusUpdateGameEventListener listener)
    { listeners.Remove(listener); }
}
