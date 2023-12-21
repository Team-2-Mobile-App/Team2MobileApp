using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperaInteractable : MonoBehaviour
{
    public Button Additional;
    public Button Missing;
    public Button Exit;
    public int AdditionalRealOperaNumber;

    public OperaData operaData => GameManager.Instance.operaSelected;

    

    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        if (!operaData.isAdditionalTaken) Additional.gameObject.SetActive(true);
        else Additional.gameObject.SetActive(false);
        if (!operaData.isComplete) Missing.gameObject.SetActive(true);
        else Missing.gameObject.SetActive(false);
        operaData.SaveOperaData();
    }

    public void AdditionalButton()
    {
        operaData.isAdditionalTaken = true;
        GameManager.Instance.inventory.Pickup(operaData);
        SoundManager.OnPlayMusicPickUpPiece?.Invoke();
        Refresh();
        
    }

    public void MissButton()
    {
        if (GameManager.Instance.inventory.ObjectSelected != null && operaData != null)
        {
            if (GameManager.Instance.inventory.ObjectSelected.operaInteractable.AdditionalRealOperaNumber == operaData.OperaNumber)
            {
                operaData.isComplete = true;
                GameManager.Instance.inventory.RemoveFromInventory(GameManager.Instance.inventory.ObjectSelected);
                SoundManager.OnPlayMusicPlacedPiece?.Invoke();
                Refresh();
            }
            else /*Debug.Log("Non corretto");*/ SoundManager.OnPlayMusicWrongPiece?.Invoke();
        }
        else return;
    }


    public void ExitButton()
    {
        operaData.CloseOpera();
        if (GameManager.Instance.operaSelected.isComplete && !GameManager.Instance.operaSelected.IsCompletedAtStart)
        {
            
            GameManager.Instance.flowGame.StateMachine.ChangeState(GameManager.Instance.flowGame.OnDialogueOperaState);
            GameManager.Instance.operaSelected.IsCompletedAtStart = true;
            operaData.SaveOperaData();
        }


        //GameManager.Instance.isMovable = true;
        //GameManager.Instance.ShowOperaUIContainer.SetActive(false);
        //Destroy(this.gameObject);
    }
}
