using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Events/Set Score Event"), System.Serializable]
public class SetScoreGameEventSO : ScriptableObject
{
    private List<SetScoreGameEventListener> listeners =
        new List<SetScoreGameEventListener>();

    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(SetScoreGameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(SetScoreGameEventListener listener)
    { listeners.Remove(listener); }
}
