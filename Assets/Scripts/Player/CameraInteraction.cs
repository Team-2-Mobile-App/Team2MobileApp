using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
    private Vector3 _touchStartPosition;
    private Vector3 _touchEndPosition;
    private Camera _camera;
    private CameraInputHandler _cameraManager;
    private RaycastHit _hit;
    public float raycastDistance = 10f;
    public float touchSensibility = 1f;
    public float touchTimeDelay;
    private float Timer;
    private Portal CheckPortal;
    private OperaData CheckOpera;
    [SerializeField] private LayerMask portalLayer;
    [SerializeField] private LayerMask operaLayer;
    [SerializeField] private LayerMask wallLayer;


    private void Start()
    {
        _camera = GetComponentInChildren<Camera>();
        _cameraManager = GetComponent<CameraInputHandler>();
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
            Timer = 0;
            _touchStartPosition = touch.position;
            CheckOpera = null;
            CheckPortal = null;
            Ray ray = _camera.ScreenPointToRay(_touchStartPosition);
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red, 1.0f);

            if (Physics.Raycast(ray, out _hit, raycastDistance))
            {
                int hitLayer = _hit.collider.gameObject.layer;

                if (hitLayer == GetIntLayer(wallLayer))
                {
                    CheckPortal = null;
                    CheckOpera = null;
                }
                if (hitLayer == GetIntLayer(portalLayer))
                {
                    if (_hit.collider.TryGetComponent(out Portal portal)) CheckPortal = portal;
                    CheckOpera = null;
                }
                if (hitLayer == GetIntLayer(operaLayer))
                {
                    if (_hit.collider.TryGetComponent(out OperaData opera)) CheckOpera = opera;
                    CheckPortal = null;
                }
            }
        }

        if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) Timer += Time.deltaTime;

        if (touch.phase == TouchPhase.Ended && GameManager.Instance.isMovable)
        {
            if (CheckPortal != null || CheckOpera != null)
            {
                _touchEndPosition = touch.position;
                Ray ray = _camera.ScreenPointToRay(_touchEndPosition);
                Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.blue, 1.0f);

                if (Physics.Raycast(ray, out _hit, raycastDistance))
                {
                    int hitLayer = _hit.collider.gameObject.layer;

                    if (hitLayer == GetIntLayer(portalLayer) && Vector3.Distance(_touchStartPosition, _touchEndPosition) <= touchSensibility && Timer <= touchTimeDelay)
                    {
                        CheckPortal.MoveToNewPosition(/*_cameraManager.CameraData.CameraTransform*/transform);
                    }
                    if (hitLayer == GetIntLayer(operaLayer) && Vector3.Distance(_touchStartPosition, _touchEndPosition) <= touchSensibility && Timer <= touchTimeDelay)
                    {
                        if (_hit.collider.TryGetComponent(out OperaData opera) && opera == CheckOpera)
                        {
                            opera.OpenOpera();
                            GameManager.Instance.operaSelected = opera;
                        }
                    }
                }
            }
        }
    }

    private int GetIntLayer(LayerMask layerMask)
    {
        return (int)Mathf.Log(layerMask.value, 2);
    }
}
