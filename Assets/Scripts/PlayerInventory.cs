using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<OperaData> MissingObjectList;
    public OperaData ObjectSelected;
    [SerializeField] private UIInventoryMissingObject uiInventory;


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
