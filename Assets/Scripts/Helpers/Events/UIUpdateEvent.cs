using UnityEngine;
namespace Helpers.Events
{
    [CreateAssetMenu(fileName = "VoidEvent", menuName = "Game Events/UI Update Event")]
    public class UIUpdateEvent : BaseGameEvent<UIData>
    {
    }
}