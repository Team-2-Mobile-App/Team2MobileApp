using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    public StateManager StateManager;




    private void Awake()
    {
        StateManager = new();
    }



    private void Update()
    {
        StateManager.CurrentState.OnUpdate();
    }



}
