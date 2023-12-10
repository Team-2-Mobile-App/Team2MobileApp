using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : StatesMachine<Enum.GameState>
{
    public CameraInputHandler CameraInput;

    public StateManager(CameraInputHandler cameraInput, Dictionary<Enum.GameState, State<Enum.GameState>> listOfSTtes = null, State<Enum.GameState> currentState = null, State<Enum.GameState> nextState = null)
    {
        CameraInput = cameraInput;
        InitStatesManager();
    }



    protected override void InitStates()
    {

        AllStates.Add(Enum.GameState.Navigation, new NavigationState(Enum.GameState.Navigation, this));

        AllStates.Add(Enum.GameState.Dialogue, new OnDialogue(Enum.GameState.Dialogue, this));




        CurrentState = AllStates[Enum.GameState.Navigation];
        CurrentState.OnEnter();
    }




}
