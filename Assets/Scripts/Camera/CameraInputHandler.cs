using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraInputHandler : MonoBehaviour
{
    private Touch _initTouch = new Touch();
    float _deltaX;
    float _deltaY;

    public static Action<float, float> OnTouchStay; 

    public static Action<float,float> OnTouchMove; 



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
            _deltaX = CameraManager.CameraTransform.transform.position.x;
            _deltaY = CameraManager.CameraTransform.transform.position.y;

            OnTouchStay?.Invoke(_deltaX,_deltaY);
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            
            _deltaX = _initTouch.position.x - touch.position.x;
            _deltaY = _initTouch.position.y - touch.position.y;

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