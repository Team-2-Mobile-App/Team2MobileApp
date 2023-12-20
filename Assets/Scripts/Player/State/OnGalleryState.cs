using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGalleryState : StateBase<FlowGameManger>
{
    public OnGalleryState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        GameManager.Instance.isMovable = false;
        contex.UIManager.GalleryPanel.gameObject.SetActive(true);
        contex.UIManager.FillContainer();
        contex.UIManager.GalleryOperaView.gameObject.SetActive(false);
    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        GameManager.Instance.isMovable = true;
        contex.UIManager.CloseGalleryPanel();
        contex.UIManager.GalleryPanel.gameObject.SetActive(false);
        contex.UIManager.CloseOperaView();
    }
 
   

   

    
   
}
