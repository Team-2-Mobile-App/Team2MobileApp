using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static Camera CameraTransform;
    float _lookAngle;
    float _pivotAngle;   
    public CameraData cameraData;
    private Vector3 _cameraFollowVelocity = Vector3.zero;
    float _followSpeed = 0;


    private void Awake()
    {
        CameraTransform = Camera.main;
    }



    private void OnEnable()
    {
        CameraInputHandler.OnTouchStay += OnRotateCamera;
        CameraInputHandler.OnTouchMove += OnRotateCamera;

    }

    private void FixedUpdate()
    {
        FollowTarget();

    }

    private void FollowTarget()
    {
        Vector3 targetPosition = 
            Vector3.SmoothDamp
                (transform.position, cameraData.Target.position + cameraData.PlayerCameraOffsetY, ref _cameraFollowVelocity,_followSpeed * Time.deltaTime);
        transform.position = targetPosition;
    }



    private void OnRotateCamera(float deltaX,float deltaY)
    {
        _lookAngle = _lookAngle + (deltaX * cameraData.CameraPitchSpeed * Time.fixedDeltaTime);
        _pivotAngle = _pivotAngle - (deltaY * cameraData.CameraYawSpeed * Time.fixedDeltaTime);

        _pivotAngle = Mathf.Clamp(_pivotAngle, cameraData.MinPitchAngle, cameraData.MaxPitchAngle);


        CameraTransform.transform.localRotation = Quaternion.Euler(_pivotAngle, _lookAngle,0);


    }


   

   

    private void OnDisable()
    {

        CameraInputHandler.OnTouchStay -= OnRotateCamera;
        CameraInputHandler.OnTouchMove -= OnRotateCamera;

    }


}


[System.Serializable]
public struct CameraData
{
    public Transform Target;
    [Range(0,10)]
    public float CameraPitchSpeed;
    [Range(0, 10)]
    public float CameraYawSpeed;
    [Range(-360,360)]
    public float MinPitchAngle;
    [Range(-360, 360)]
    public float MaxPitchAngle;
    public Vector3 PlayerCameraOffsetY;
}