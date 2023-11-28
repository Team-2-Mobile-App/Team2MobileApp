using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<OperaData> Opera;
    [SerializeField] private UIInventory uiInventory;


    private void Start()
    {
        uiInventory.Open(Opera);
    }

    public void Pickup(OperaData data)
    {
        //Debug.Log("Pickup: " + pokemon);
        Opera.Add(data);
        uiInventory.PopulateItemsSection(Opera);
    }

    public void Drop(OperaData data)
    {
        var go = Instantiate(Opera[0].MissingObject, transform.position + transform.forward * 2 + transform.up, Quaternion.identity);
        RemoveFromInventory(data);
        //items.TrimExcess();
    }

    private void RemoveFromInventory(OperaData data)
    {
        Opera.Remove(data);
    }



    /// <summary>
    /// TESTING
    /// </summary>
    void Update()
    {
        if (IsNotTouching()) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            Pickup(Opera[1]);

        }

    }

    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);

    }

}
