using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NavigationState : State<Enum.GameState>
{

    Camera _cameraTransform;
    float _lookAngle;
    float _pivotAngle;
    public CameraData cameraData;
    private Vector3 _cameraFollowVelocity = Vector3.zero;
    float _followSpeed = 0;
    StateManager _stateManager;


    public NavigationState(Enum.GameState playerState, StatesMachine<Enum.GameState> stateManager = null) : base(playerState, stateManager)
    {
        _stateManager = (StateManager)stateManager;
    }


    public override void OnEnter()
    {
        base.OnEnter();
        _cameraTransform = Camera.main;
        cameraData = _stateManager.CameraInput.CameraData;

        ActionManager.OnTouchStay += OnRotateCamera;
        ActionManager.OnTouchMove += OnRotateCamera;
    }


    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        FollowTarget();
        //Debug.Log(cameraData.CameraPitchSpeed);
    }


    public override void OnExit()
    {
        base.OnExit();

        ActionManager.OnTouchStay -= OnRotateCamera;
        ActionManager.OnTouchMove -= OnRotateCamera;

        
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

