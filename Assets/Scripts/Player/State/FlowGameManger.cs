using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    private StatesMachine<FlowGameManger> StateMachine;

    private MuseumGuide _museumGuide;
    public MuseumGuide MuseumGuide { get => _museumGuide; }


    public OnNavigationState OnNavigationState;
    public OnDialogueState OnDialogueState;

    private void Awake()
    {
        InitStateMachine();
        _museumGuide = FindObjectOfType<MuseumGuide>();
        
    }


    private void Update()
    {
        StateMachine.CurrentState.OnUpdate(this);
    }

    private void InitStateMachine()
    {
        StateMachine = new StatesMachine<FlowGameManger>(this);
        OnNavigationState = new OnNavigationState("OnNavigationState", StateMachine);
        OnDialogueState = new OnDialogueState("OnDialogueState", StateMachine);
        StateMachine.RunStateMachine(OnNavigationState);
    }
}
