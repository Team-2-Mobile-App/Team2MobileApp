using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPauseState : StateBase<FlowGameManger>
{

    PlayerInventory _inventory;


    public OnPauseState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        GameManager.Instance.isMovable = false;
        SetUp();
        contex.UIManager.EnablePoseMenu(true);
        contex.UIManager.PauseButton.gameObject.SetActive(false);
        
    }



    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        contex.UIManager.MapImage.gameObject.SetActive(false);
        GameManager.Instance.isMovable = true;
        contex.UIManager.CloseOperaView();

    }


    private void SetUp()
    {
        _inventory = Camera.main.GetComponentInParent<PlayerInventory>();
        _inventory.UIInventory.Close();
    }


}
