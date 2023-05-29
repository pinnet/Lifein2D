using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("!! Trying to create another singleton? destroying this one !! :" + this);
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    public Vector2 GetMouseScreenPosition()
    {
        return Input.mousePosition;
    }
    public bool IsMouseButtonDown()
    {
        return Input.GetMouseButtonDown(0);
    }
    public Vector2 GetCameraMoveVector()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
