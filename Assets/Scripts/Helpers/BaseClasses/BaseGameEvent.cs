using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Events
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private List<IGameEventListener<T>> eventListeners =
            new List<IGameEventListener<T>>();

        public void Raise(T value)
        {
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }            
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        { 
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }
    }
}
