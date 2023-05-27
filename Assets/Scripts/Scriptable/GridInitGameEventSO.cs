using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Events/Grid Init Event"), System.Serializable]
public class GridInitGameEventSO : ScriptableObject
{
    private List<GridInitGameEventListener> listeners =
        new List<GridInitGameEventListener>();

    public void Raise(int width,int height,float cellSize)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(width,height,cellSize);
    }

    public void RegisterListener(GridInitGameEventListener listener)
    { listeners.Add(listener); }

    public void UnregisterListener(GridInitGameEventListener listener)
    { listeners.Remove(listener); }
}
