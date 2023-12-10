using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    public StateManager StateManager;

    CameraInputHandler CameraInput;


    private void Awake()
    {
        CameraInput = FindObjectOfType<CameraInputHandler>();
        StateManager = new StateManager(CameraInput);
    }

    private void Start()
    {
        StateManager.CurrentState.OnEnter();
    }


    private void Update()
    {
        StateManager.CurrentState.OnUpdate();
    }




    private void FixedUpdate()
    {
        StateManager.CurrentState.OnFixedUpdate();
    }

}
