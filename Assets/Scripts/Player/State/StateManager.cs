using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : StatesMachine<Enum.GameState>
{

    public StateManager(Dictionary<Enum.GameState, State<Enum.GameState>> listOfSTtes = null, State<Enum.GameState> currentState = null, State<Enum.GameState> nextState = null)
    {

        InitStatesManager();
    }



    protected override void InitStates()
    {

        AllStates.Add(Enum.GameState.Navigation, new NavigationState(Enum.GameState.Navigation, this));




        CurrentState = AllStates[Enum.GameState.Navigation];
        CurrentState.OnEnter();
    }




}
