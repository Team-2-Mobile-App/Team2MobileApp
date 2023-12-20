using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScanState : StateBase<FlowGameManger>
{

    public static event Action<bool> OnScan;
    public static event Action<bool> ActiveVuforia;
    public OnScanState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }


    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        OnScan?.Invoke(false);
        ActiveVuforia?.Invoke(true);
    }


    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        OnScan?.Invoke(true);
        ActiveVuforia?.Invoke(false);
    }

}
