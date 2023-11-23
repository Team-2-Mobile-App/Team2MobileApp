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
            _deltaX = 0;
            _deltaY = 0;

            OnTouchStay?.Invoke(_deltaX,_deltaY);
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