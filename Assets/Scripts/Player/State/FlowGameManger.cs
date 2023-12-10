using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    public StateManager StateManager;

    CameraInputHandler CameraInput;

    public bool Debugger;

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
        if (Debugger)
        {
            StateManager.ChangeState(Enum.GameState.Dialogue);
        }
        
    }




    private void FixedUpdate()
    {
        StateManager.CurrentState.OnFixedUpdate();
    }

}
