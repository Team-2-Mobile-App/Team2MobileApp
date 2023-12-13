using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    private Vector2 touchStartPos;
    private Vector2 touchDelta;
    [SerializeField] private float _zoomSpeed;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchDelta = touch.position - touchStartPos;
                transform.Translate(-touchDelta * Time.deltaTime);
            }
        }

        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 prevPos1 = touch1.position - touch1.deltaPosition;
            Vector2 prevPos2 = touch2.position - touch2.deltaPosition;

            float prevTouchDeltaMag = (prevPos1 - prevPos2).magnitude;
            float touchDeltaMag = (touch1.position - touch2.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            
            transform.localScale += new Vector3(1, 1, 0) * deltaMagnitudeDiff * _zoomSpeed;
        }
    }
}
