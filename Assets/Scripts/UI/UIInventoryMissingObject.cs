using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryMissingObject : MonoBehaviour
{
    private List<OperaData> missingObject = new List<OperaData>();
    [SerializeField] private UIMissingObject missingObjectUI;
    [SerializeField] private Transform itemsSection;



    private void OnEnable()
    {
        OnScanState.OnScan += OnScanEnabled;
    }

    public void Open(List<OperaData> data)
    {
        gameObject.SetActive(true);
        //if (operaData.Count < 0) return;
        PopulateItemsSection(data);
    }

    public void PopulateItemsSection(List<OperaData> data)
    {
        ClearAll();
        missingObject.AddRange(data);
        foreach (OperaData item in missingObject)
        {
            AddCard(item);
        }
    }

    private void AddCard(OperaData item)
    {
        var card = Instantiate(missingObjectUI, itemsSection);
        card.Setup(item);
    }

    public void Close()
    {
        ClearList();
        DeleteAllChildren();
        gameObject.SetActive(false);
    }

    private void ClearList()
    {
        missingObject.Clear();
    }

    private void ClearAll()
    {
        ClearList();
        DeleteAllChildren();
    }

    private void DeleteAllChildren()
    {
        foreach (Transform child in itemsSection)
        {
            if (child != itemsSection) Destroy(child.gameObject);
        }
    }

    private void OnScanEnabled(bool isActive) => gameObject.SetActive(isActive);


    private void OnDisable()
    {
        OnScanState.OnScan -= OnScanEnabled;
    }
}
