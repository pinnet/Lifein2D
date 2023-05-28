using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Helpers.Events
{
    [System.Serializable]
    public class UnityUIUpdateEvent : UnityEvent<UIData>
    { 
    }
}
