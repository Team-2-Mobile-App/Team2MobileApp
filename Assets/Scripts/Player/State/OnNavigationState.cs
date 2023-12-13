using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OnNavigationState : StateBase<FlowGameManger>
{
    Camera _cameraTransform;
    float _lookAngle;
    float _pivotAngle;
    public CameraData cameraData;
    private Vector3 _cameraFollowVelocity = Vector3.zero;
    float _followSpeed = 0;
    PlayerInventory inventory;
    

    public OnNavigationState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base (stateID , statesMachine)
    {

    }


    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        SetUp();

        inventory.UIInventory.Open(inventory.MissingObjectList);

        CameraInputHandler.OnTouchStay += OnRotateCamera;
        CameraInputHandler.OnTouchMove += OnRotateCamera;
    }


    public override void OnFixedUpdate(FlowGameManger contex)
    {
        base.OnFixedUpdate(contex);
        FollowTarget();
        //Debug.Log(cameraData.CameraPitchSpeed);
    }


    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);

        CameraInputHandler.OnTouchStay -= OnRotateCamera;
        CameraInputHandler.OnTouchMove -= OnRotateCamera;
 
    }


    private void SetUp()
    {
        _cameraTransform = Camera.main;
        cameraData = _cameraTransform.GetComponentInParent<CameraInputHandler>().CameraData;
        inventory = _cameraTransform.GetComponentInParent<PlayerInventory>();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition =
        Vector3.SmoothDamp
                (cameraData.CameraTransform.position, cameraData.Target.position + cameraData.PlayerCameraOffsetY, ref _cameraFollowVelocity, _followSpeed * Time.fixedDeltaTime);
        cameraData.CameraTransform.position = targetPosition;
    }


    private void OnRotateCamera(float deltaX, float deltaY)
    {

        _lookAngle = _lookAngle + (deltaX * cameraData.CameraPitchSpeed * Time.deltaTime);
        _pivotAngle = _pivotAngle - (deltaY * cameraData.CameraYawSpeed * Time.deltaTime);

        _pivotAngle = Mathf.Clamp(_pivotAngle, cameraData.MinPitchAngle, cameraData.MaxPitchAngle);

        _cameraTransform.transform.localRotation = Quaternion.Euler(_pivotAngle, _lookAngle, 0);

    }

}

