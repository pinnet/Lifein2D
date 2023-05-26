using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Select Cell Event"), System.Serializable]
public class SelectCellGameEventSO : ScriptableObject
{
    private List<SelectCellGameEventListener> listeners =
        new List<SelectCellGameEventListener>();

    public void Raise(Vector2 value1,bool value2)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value1,value2);
    }

    public void RegisterListener(SelectCellGameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(SelectCellGameEventListener listener)
    { listeners.Remove(listener); }
}
