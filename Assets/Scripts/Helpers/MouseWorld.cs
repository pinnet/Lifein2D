using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MouseWorld : MonoBehaviour
{
    
    private static MouseWorld Instance;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject pointer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pointer.SetActive(false);
    }
    
    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue,Instance.layerMask))
        {
            return raycastHit.point;
        }
      return Vector3.zero;
    }
}
