using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public List<OperaData> MissingObjectList;
    [HideInInspector] public OperaData ObjectSelected;
    [HideInInspector] public UIInventoryMissingObject UIInventory;


    private void Awake()
    {
        UIInventory = FindObjectOfType<UIInventoryMissingObject>();
    }

    public void DeleteDublicateObject()
    {
        foreach (var item in MissingObjectList)
        {
            if(item.isComplete) 
                foreach (var item1 in MissingObjectList)
                {
                    OperaInteractable operaInteractable = item1.PrefabUIOpera.GetComponent<OperaInteractable>();
                    if (operaInteractable.AdditionalRealOperaNumber == item.OperaNumber) RemoveFromInventory(item1);
                }
        }
    }


    public void Pickup(OperaData data)
    {
        MissingObjectList.Add(data);
        UIInventory.PopulateItemsSection(MissingObjectList);
    }

    public void RemoveFromInventory(OperaData data)
    {
        MissingObjectList.Remove(data);
        UIInventory.PopulateItemsSection(MissingObjectList);
    }


}
