using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    //[SerializeField] private float jumpForce = 1f;
    [SerializeField] private float stoppingDistance = 0.1f;   

    private Vector3 _targetPosition;

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targetPosition) < stoppingDistance) return;
        Vector3 moveDirection = (_targetPosition - transform.position).normalized;
        transform.position += moveDirection * (speed * Time.deltaTime);
    }


    private void Move(Vector3 targetPosition)
    {
        this._targetPosition = targetPosition;  
    }

    public void keyPress() 
    { 
     Debug.Log("key pressed");
    
    }

}
