using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject pointer;

    private Vector3 validPosition;
    private Vector3 lastValitPosition;

    private void Start()
    {
        validPosition = this.transform.position;
        lastValitPosition = validPosition;
        pointer.SetActive(false);
    }
    
    


    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Canceled)
        {
            pointer.SetActive(false);
        }

        if (ctx.phase != InputActionPhase.Performed) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            this.transform.position = raycastHit.point;
            pointer.SetActive(true);
        }    
    }

}
