using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OperaData : MonoBehaviour
{
    public int OperaNumber;
    public GameObject PrefabUIOpera;
    public bool isAdditionalTaken;
    public OperaDataSO operaData;
    public OperaInteractable operaInteractable;
    public bool isSpotted, isComplete,IsCompletedAtStart, isScanned;



    private GameObject InstantiateObject;

    private void Awake()
    {
        operaInteractable = PrefabUIOpera.GetComponent<OperaInteractable>();
    }
    public void OpenOpera()
    {
        GameManager.Instance.ShowOperaUIContainer.SetActive(true);
        GameManager.Instance.isMovable = false;
        InstantiateObject = Instantiate(PrefabUIOpera, GameManager.Instance.ShowOperaUIContainer.transform);
    }

    public void CloseOpera()
    {
        GameManager.Instance.ShowOperaUIContainer.SetActive(false);
        GameManager.Instance.isMovable = true;
        Destroy(InstantiateObject);
    }
}
