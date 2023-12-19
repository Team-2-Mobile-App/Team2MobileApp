using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public List<OperaData> MissingObjectList;
    [HideInInspector] public OperaData ObjectSelected;
    public UIInventoryMissingObject UIInventory;
    



    public void DeleteDublicateObject()
    {
        List<OperaData> DuplicateObjects = new List<OperaData>();

        foreach (var operaList in GameManager.Instance.operaList)
        {
            if (operaList.isComplete)
            {
                foreach (var item in MissingObjectList)
                {
                    OperaInteractable operaInteractable = item.PrefabUIOpera.GetComponent<OperaInteractable>();
                    if (operaInteractable != null && operaList.OperaNumber == operaInteractable.AdditionalRealOperaNumber) DuplicateObjects.Add(item);
                }
            }
        }
        foreach (var duplicate in DuplicateObjects)
        {
            RemoveFromInventory(duplicate);
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
