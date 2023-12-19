using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoginState : StateBase<FlowGameManger>
{
    public OnLoginState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }
}
