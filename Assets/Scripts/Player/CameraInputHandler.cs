using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraInputHandler : MonoBehaviour
{
    private Touch _initTouch = new Touch();
    float _deltaX;
    float _deltaY;


    public CameraData CameraData;

    public static event Action<float, float> OnTouchStay;
    public static  event Action<float, float> OnTouchMove;


    void Update()
    {
        CameraMove();
    }


    private void CameraMove()
    {
        if (IsNotTouching()) return;
        if (!GameManager.Instance.isMovable) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            _initTouch = touch;
        }
        else if (touch.phase == TouchPhase.Stationary)
        {
            _deltaX = 0;
            _deltaY = 0;

            OnTouchStay?.Invoke(_deltaX, _deltaY);
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            _deltaX = touch.deltaPosition.x;
            _deltaY = touch.deltaPosition.y;

            OnTouchMove?.Invoke(_deltaX, _deltaY);

        }
        else if (touch.phase == TouchPhase.Ended)
        {
            _initTouch = new Touch();

        }
    }


    
    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);


    }
}


[System.Serializable]
public struct CameraData
{
    public Transform Target;
    public Transform CameraTransform;
    [Range(0, 100)]
    public float CameraPitchSpeed;
    [Range(0, 100)]
    public float CameraYawSpeed;
    [Range(-360, 360)]
    public float MinPitchAngle;
    [Range(-360, 360)]
    public float MaxPitchAngle;
    public Vector3 PlayerCameraOffsetY;
}



