using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    public StatesMachine<FlowGameManger> StateMachine;

    public NavigationState NavigationState;
    public OnDialogue OnDialogue;

    public bool debugger;

    private void Awake()
    {
        InitStateMachine();
    }



    private void InitStateMachine()
    {
        StateMachine = new StatesMachine<FlowGameManger>(this);
        NavigationState = new NavigationState("NavigationState",StateMachine);
        OnDialogue = new OnDialogue("OnDialogue", StateMachine);
        StateMachine.RunStateMachine(NavigationState);
    }
}
