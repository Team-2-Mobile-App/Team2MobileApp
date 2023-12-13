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
        SetUp();
        contex.UIManager.EnablePoseMenu(true);
        contex.UIManager.PauseButton.gameObject.SetActive(false);
        
    }



    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);


        // da sistemare con il codice di michele
        contex.UIManager.EnablePoseMenu(false);
        contex.UIManager.PauseButton.gameObject.SetActive(true);
        
    }


    private void SetUp()
    {
        _inventory = Camera.main.GetComponentInParent<PlayerInventory>();
        _inventory.UIInventory.Close();
    }


}
