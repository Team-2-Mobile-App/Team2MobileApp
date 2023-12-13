using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManger : MonoBehaviour
{
    /// <summary>
    /// Non mi piace serve a michele meglio privato
    /// </summary>
    public StatesMachine<FlowGameManger> StateMachine;

    private MuseumGuide _museumGuide;
    public MuseumGuide MuseumGuide { get => _museumGuide; }

    private UIManager _uIManager;
    public UIManager UIManager { get => _uIManager; }

    #region States
    public OnNavigationState OnNavigationState;
    public OnDialogueState OnDialogueState;
    public OnPauseState OnPauseState;
    #endregion

    public bool debugger;
    private void Awake()
    {
        InitStateMachine();
        _museumGuide = FindObjectOfType<MuseumGuide>();
        
    }


    private void Update()
    {
        if (debugger)
        {
            StateMachine.ChangeState(OnDialogueState);
            debugger = false;
        }
        StateMachine.CurrentState.OnUpdate(this);
    }

    private void InitStateMachine()
    {
        StateMachine = new StatesMachine<FlowGameManger>(this);
        OnNavigationState = new OnNavigationState("OnNavigationState", StateMachine);
        OnDialogueState = new OnDialogueState("OnDialogueState", StateMachine);
        OnPauseState = new OnPauseState("OnPauseState", StateMachine);
        StateMachine.RunStateMachine(OnNavigationState);
    }
}
