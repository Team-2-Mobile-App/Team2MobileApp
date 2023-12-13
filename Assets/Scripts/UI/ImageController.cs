using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    float _deltaX;
    float _deltaY;
    [SerializeField] private float _mapMuveVelocity;
    private RectTransform _imageInitialTransform;
    private Vector3 _initialPosition;



    private void Start()
    {
        _imageInitialTransform = GetComponent<RectTransform>();
        _initialPosition = _imageInitialTransform.anchoredPosition3D;
        _imageInitialTransform.localPosition = transform.localPosition;

    }


    void Update()
    {
        MapControll();

    }

    private void MapControll()
    {
        if (IsNotTouching()) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved)
        {
            _deltaX = touch.deltaPosition.x;
            _deltaY = touch.deltaPosition.y;
            Vector2 delta = new Vector2(_deltaX, _deltaY);
            transform.Translate(delta * Time.deltaTime * _mapMuveVelocity);
        }
    }

    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);


    }

    private void OnDisable()
    {
        _imageInitialTransform.anchoredPosition3D = _initialPosition;

    }



    
}
