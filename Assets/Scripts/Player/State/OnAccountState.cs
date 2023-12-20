using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAccountState : StateBase<FlowGameManger>
{
    public OnAccountState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        GameManager.Instance.isMovable = false;
        contex.UIManager.accountPage.gameObject.SetActive(true);
    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        GameManager.Instance.isMovable = true;
        contex.UIManager.accountPage.gameObject.SetActive(false);
    }
}
