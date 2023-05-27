// Ignore Spelling: UER
using UnityEngine.Events;
using UnityEngine;

namespace Helpers.Events
{
    public abstract class BaseGameEventListener<T,E,UER> : MonoBehaviour,
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E gameEvent;
        [SerializeField] private UER unityEventResponse;

        public E GameEvent { get => gameEvent; set => gameEvent = value; }
      
        private void OnEnable()
        {
            if(gameEvent == null) return;
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if(gameEvent == null) return;
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T value)
        {
            if(unityEventResponse == null) return;
            unityEventResponse.Invoke(value);
        }

    }
   
}
