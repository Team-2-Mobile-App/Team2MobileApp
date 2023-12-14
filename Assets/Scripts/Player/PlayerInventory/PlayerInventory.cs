using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public List<OperaData> MissingObjectList;
    [HideInInspector] public OperaData ObjectSelected;
    public UIInventoryMissingObject UIInventory;


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
