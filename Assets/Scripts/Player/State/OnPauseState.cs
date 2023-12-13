using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPauseState : StateBase<FlowGameManger>
{

    

    public OnPauseState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);

    }



}
