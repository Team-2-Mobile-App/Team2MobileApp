using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryMissingObject : MonoBehaviour
{
    public List<OperaData> MissingObject;
    [SerializeField] private UIInventoryMissingObject uiInventory;


    private void Start()
    {
        uiInventory.Open(MissingObject);
    }

    public void Pickup(OperaData data)
    {
        //Debug.Log("Pickup: " + pokemon);
        MissingObject.Add(data);
        uiInventory.PopulateItemsSection(MissingObject);
    }

    public void Drop(OperaData data)
    {
        var go = Instantiate(MissingObject[0].MissingObject, transform.position + transform.forward * 2 + transform.up, Quaternion.identity);
        RemoveFromInventory(data);
        //items.TrimExcess();
    }

    private void RemoveFromInventory(OperaData data)
    {
        MissingObject.Remove(data);
        uiInventory.PopulateItemsSection(MissingObject);

    }


}
