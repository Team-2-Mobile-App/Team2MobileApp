using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogue : StateBase<FlowGameManger>
{


    public OnDialogue(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }



    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        ActionManager.OnDialogueStarts?.Invoke();

    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        ActionManager.OnDialogueEnds?.Invoke();
    }



}
