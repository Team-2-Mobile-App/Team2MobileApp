using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    float deltaX;
    float deltaY;
    public CameraData cameraData;
    private Touch initTouch = new Touch();
    private Vector3 cameraFollowVelocity = Vector3.zero;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                deltaX = cameraData.cameraTransform.position.x;
                deltaY = cameraData.cameraTransform.position.y;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                deltaX = initTouch.position.x - touch.position.x;
                deltaY = initTouch.position.y - touch.position.y;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                deltaX = 0;
                deltaY = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        //FollowTarget();
        RotateCamera();

    }

    //private void FollowTarget()
    //{
    //    Vector3 targetPosition = Vector3.SmoothDamp(transform.position, cameraData.target.position, ref cameraFollowVelocity, cameraData.followSpeed);

    //    transform.position = targetPosition;
    //}


    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        cameraData.lookAngle = cameraData.lookAngle + (deltaX * cameraData.cameraPitchSpeed * Time.fixedDeltaTime);
        cameraData.pivotAngle = cameraData.pivotAngle - (deltaY * cameraData.cameraYawSpeed * Time.fixedDeltaTime);

        cameraData.pivotAngle = Mathf.Clamp(cameraData.pivotAngle, cameraData.minPitchAngle, cameraData.maxPitchAngle);

        rotation = Vector3.zero;
        rotation.y = cameraData.lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = cameraData.pivotAngle;

        targetRotation = Quaternion.Euler(rotation);
        cameraData.cameraPivot.localRotation = targetRotation;

    }



}


[System.Serializable]
public struct CameraData
{
    public Transform target;
    public Transform cameraPivot;
    public Transform cameraTransform;
    public float followSpeed;

    [HideInInspector]
    public float lookAngle;
    [HideInInspector]
    public float pivotAngle;

    public float cameraPitchSpeed;
    public float cameraYawSpeed;

    public float minPitchAngle;
    public float maxPitchAngle;
 
}