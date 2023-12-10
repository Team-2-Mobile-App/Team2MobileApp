using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogue : State<Enum.GameState>
{


    public OnDialogue(Enum.GameState playerState, StatesMachine<Enum.GameState> stateManager = null) : base(playerState, stateManager)
    {


    }


    public override void OnEnter()
    {
        base.OnEnter();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        DialogueSkip();
    }




    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);

    }




    void DialogueSkip()
    {
        if (IsNotTouching()) return;
        
        Input.GetTouch(0);
        
        
    }



}
