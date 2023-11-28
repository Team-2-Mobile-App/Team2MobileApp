using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private List<OperaData> operaData = new List<OperaData>();
    [SerializeField] private UIOperaCard operaCard;
    [SerializeField] private Transform itemsSection;


   
    public void Open(List<OperaData> data)
    {
        gameObject.SetActive(true);
        //if (operaData.Count < 0) return;
        PopulateItemsSection(data);
    }

    public void PopulateItemsSection(List<OperaData> data)
    {
        ClearAll();
        operaData.AddRange(data);
        foreach (OperaData item in operaData)
        {
            AddCard(item);
        }
    }

    private void AddCard(OperaData item)
    {
        var card = Instantiate(operaCard, itemsSection);
        card.Setup(item);
    }

    public void Close()
    {
        ClearListPokemon();
        DeleteAllChildren();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }

    private void ClearListPokemon()
    {
        operaData.Clear();
    }

    private void ClearAll()
    {
        ClearListPokemon();
        DeleteAllChildren();
    }

    private void DeleteAllChildren()
    {
        foreach (Transform child in itemsSection)
        {
            if (child != itemsSection) Destroy(child.gameObject);
        }
    }


}
