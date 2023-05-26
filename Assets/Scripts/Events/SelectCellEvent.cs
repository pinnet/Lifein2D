using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SelectCellEvent : UnityEvent<Vector2,bool>
{
}