using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [HideInInspector] public List<OperaData> MissingObjectList;
    [HideInInspector] public OperaData ObjectSelected;
    private UIInventoryMissingObject uiInventory;

    private void Awake()
    {
        uiInventory = GetComponentInChildren<UIInventoryMissingObject>();
    }

    private void Start()
    {
        uiInventory.Open(MissingObjectList);
    }

    public void Pickup(OperaData data)
    {
        MissingObjectList.Add(data);
        uiInventory.PopulateItemsSection(MissingObjectList);
    }

    //public void Drop(OperaData data)
    //{
    //    var go = Instantiate(MissingObject[0].MissingObject, transform.position + transform.forward * 2 + transform.up, Quaternion.identity);
    //    RemoveFromInventory(data);
    //    //items.TrimExcess();
    //}

    public void RemoveFromInventory(OperaData data)
    {
        MissingObjectList.Remove(data);
        uiInventory.PopulateItemsSection(MissingObjectList);
    }


}
