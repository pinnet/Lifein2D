using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Events/Update Score Event"), System.Serializable]
public class ScoreUpdateGameEventSO : ScriptableObject
{
    private List<ScoreUpdateGameEventListener> listeners =
        new List<ScoreUpdateGameEventListener>();

    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(ScoreUpdateGameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(ScoreUpdateGameEventListener listener)
    { listeners.Remove(listener); }
}
