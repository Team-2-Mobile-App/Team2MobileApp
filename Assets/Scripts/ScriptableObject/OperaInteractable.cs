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
    }

    public void AdditionalButton()
    {
        operaData.isAdditionalTaken = true;
        GameManager.Instance.inventory.Pickup(operaData);
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
                Refresh();
            }
            else Debug.Log("Non corretto");
        }
        else return;
    }

    public void ExitButton()
    {
        operaData.CloseOpera();
        //GameManager.Instance.isMovable = true;
        //GameManager.Instance.ShowOperaUIContainer.SetActive(false);
        //Destroy(this.gameObject);
    }
}
