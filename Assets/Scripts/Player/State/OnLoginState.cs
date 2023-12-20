using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoginState : StateBase<FlowGameManger>
{
    public OnLoginState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }
    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        GameManager.Instance.isMovable = false;
        contex.UIManager.loginPage.gameObject.SetActive(true);
        contex.UIManager.EnablePoseMenu(true);
    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        GameManager.Instance.isMovable = true;
        contex.UIManager.loginPage.gameObject.SetActive(false);
        contex.UIManager.EnablePoseMenu(false);
    }
}
