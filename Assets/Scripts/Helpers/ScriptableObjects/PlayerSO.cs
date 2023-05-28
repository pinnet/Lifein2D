using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player.asset", menuName = "Player")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] Object payer;
    [SerializeField] Color color;
}
