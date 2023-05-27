using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class CameraController : MonoBehaviour
{
  
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float zoomSpeed = 0.00003F;
    
    [SerializeField] private float _maxZoom = 12f;
    [SerializeField] private float _minZoom = 0.5f;


    private float _zoom = 0;
    
    private Vector2 _mouseDelta;
   

    private void Start()
    {
        _mouseDelta = Vector2.zero;
        _zoom = Camera.main.orthographicSize;
    }
    private void LateUpdate()
    {
        transform.position += transform.forward * _mouseDelta.y * moveSpeed * _zoom * Time.deltaTime;
        transform.position += transform.right * _mouseDelta.x * moveSpeed * _zoom * Time.deltaTime;
        _mouseDelta = Vector2.zero;
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, _zoom, Time.deltaTime);             
    }
    public void OnMove(InputAction.CallbackContext ctx)
    { 
        if (ctx.phase != InputActionPhase.Performed) return;
        _mouseDelta =ctx.ReadValue<Vector2>();
        _mouseDelta = -_mouseDelta;
        _mouseDelta.x = Mathf.Clamp(_mouseDelta.x, -1, 1);
        _mouseDelta.y = Mathf.Clamp(_mouseDelta.y, -1, 1);  

   
    }
    public void OnDrag(InputAction.CallbackContext ctx)
    {
       
    }
    public void OnRotate(InputAction.CallbackContext ctx)
    {
       
    }
    public void OnZoom(InputAction.CallbackContext ctx)
    {
       if (ctx.phase != InputActionPhase.Performed) return;
      

        Vector2 wheel = ctx.ReadValue<Vector2>();

        wheel = -wheel; // inverse the scroll wheel value

        _zoom += wheel.y * zoomSpeed;
      
        if(_zoom > _maxZoom)
        {
            _zoom = _maxZoom;
        }
        if(_zoom < _minZoom)
        {
            _zoom = _minZoom;
        }
      
       
    }

}

