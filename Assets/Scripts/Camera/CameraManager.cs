using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    float _lookAngle;
    float _pivotAngle;
    float _deltaX;
    float _deltaY;
    public CameraData cameraData;
    private Touch _initTouch = new Touch();
    private Vector3 _cameraFollowVelocity = Vector3.zero;
    float _followSpeed = 0;


    void Update()
    {
        if (IsNotTouching()) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            _initTouch = touch;
        }
        else if (touch.phase == TouchPhase.Stationary)
        {
            _deltaX = cameraData.cameraTransform.position.x;
            _deltaY = cameraData.cameraTransform.position.y;
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            _deltaX = _initTouch.position.x - touch.position.x;
            _deltaY = _initTouch.position.y - touch.position.y;

        }
        else if (touch.phase == TouchPhase.Ended)
        {
            _deltaX = 0;
            _deltaY = 0;
        }

    }

    private void FixedUpdate()
    {
        FollowTarget();
        RotateCamera();

    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, cameraData.target.position + cameraData.playerCameraOffsetY, ref _cameraFollowVelocity,_followSpeed * Time.deltaTime);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        _lookAngle = _lookAngle + (_deltaX * cameraData.cameraPitchSpeed * Time.fixedDeltaTime);
        _pivotAngle = _pivotAngle + (_deltaY * cameraData.cameraYawSpeed * Time.fixedDeltaTime);

        _pivotAngle = Mathf.Clamp(_pivotAngle, cameraData.minPitchAngle, cameraData.maxPitchAngle);

        rotation = Vector3.zero;
        rotation.y = _lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = _pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraData.cameraTransform.localRotation = targetRotation;

    }

    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);

    }

}


[System.Serializable]
public struct CameraData
{

    public Transform target;
    public Transform cameraTransform;
    
    [Range(0,10)]
    public float cameraPitchSpeed;
    [Range(0, 10)]
    public float cameraYawSpeed;
    [Range(-360,360)]
    public float minPitchAngle;
    [Range(-360, 360)]
    public float maxPitchAngle;

    public Vector3 playerCameraOffsetY;
}