using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _touchStartPosition;
    private Vector3 _touchEndPosition;
    private Camera _camera;
    private RaycastHit _hit;
    public float raycastDistance = 10f;
    public float touchSensibility = 1f;
    private Portal CheckPortal;
    private OperaData CheckOpera;
    public LayerMask portalLayer;
    public LayerMask OperaLayer;

    private CameraManager _cameraManager;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _cameraManager = GetComponentInParent<CameraManager>();
    }

    private void Update()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began && GameManager.Instance.isMovable)
        {
            _touchStartPosition = touch.position;
            Ray ray = _camera.ScreenPointToRay(_touchStartPosition);
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red, 1.0f);

            if (Physics.Raycast(ray, out _hit, raycastDistance, portalLayer))
            {
                if (_hit.collider.TryGetComponent(out Portal portal))
                {
                    Debug.Log("Entrato");
                    CheckPortal = portal;
                }
                else CheckPortal = null;
            }

            if (Physics.Raycast(ray, out _hit, raycastDistance, OperaLayer))
            {
                if (_hit.collider.TryGetComponent(out OperaData Opera))
                {
                    Debug.Log("Preso");
                    CheckOpera = Opera;
                }
                else CheckOpera = null;
            }
        }

        if (touch.phase == TouchPhase.Ended && GameManager.Instance.isMovable)
        {
            _touchEndPosition = touch.position;
            Ray ray = _camera.ScreenPointToRay(_touchEndPosition);
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.blue, 1.0f);

            if (CheckPortal != null && Vector3.Distance(_touchStartPosition, _touchEndPosition) <= touchSensibility)
            {
                CheckPortal.MoveToNewPosition(_cameraManager.cameraData.Target);
                CheckPortal = null;
            } 
            else CheckPortal = null;

            if (Physics.Raycast(ray, out _hit, raycastDistance, OperaLayer))
            {
                if (_hit.collider.TryGetComponent(out OperaData Opera) && Opera == CheckOpera && Vector3.Distance(_touchStartPosition, _touchEndPosition) <= touchSensibility)
                {
                    Debug.Log("CheckSuperato");
                    Opera.OpenOpera();
                    GameManager.Instance.operaSelected = Opera;
                }
                else CheckOpera = null;
            }
        }
    }
}
