using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationState : State<Enum.GameState>
{

    

    public NavigationState(Enum.GameState playerState, StatesMachine<Enum.GameState> stateManager = null) : base(playerState, stateManager)
    {


    }





}
