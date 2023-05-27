using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Events/Update Move Event"), System.Serializable]
public class MoveUpdateGameEventSO : ScriptableObject
{
    private List<MoveUpdateGameEventListener> listeners =
        new List<MoveUpdateGameEventListener>();

    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(MoveUpdateGameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(MoveUpdateGameEventListener listener)
    { listeners.Remove(listener); }
}
