using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogue : State<Enum.GameState>
{


    public OnDialogue(Enum.GameState playerState, StatesMachine<Enum.GameState> stateManager = null) : base(playerState, stateManager)
    {


    }


}
