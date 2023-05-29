using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Helpers.Events;

public class DisplayGridHilight : MonoBehaviour
{
    [SerializeField] private Transform quad;
    
    public void SetVisibility(bool visibility)
    {

        if(visibility)
        {
            quad.gameObject.SetActive(true);
        }
        else
        {
            quad.gameObject.SetActive(false);
        }

    }
    public void Remove()
    {
        gameObject.SetActive(false);
        Destroy(gameObject,1f);
    }
    
}
