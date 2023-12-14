using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OperaData : MonoBehaviour
{
    public int OperaNumber;
    public GameObject PrefabUIOpera;
    public OperaDataSO operaData;
    public OperaInteractable operaInteractable;
    public bool isAdditionalTaken;
    public bool isComplete,IsCompletedAtStart, isScanned;



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

    public void SaveOperaData()
    {
        PlayerPrefs.SetInt("isComplete" + OperaNumber, isComplete ? 1 : 0);
        PlayerPrefs.SetInt("IsCompletedAtStart" + OperaNumber, IsCompletedAtStart ? 1 : 0);
        PlayerPrefs.SetInt("isScanned" + OperaNumber, isScanned ? 1 : 0);
        PlayerPrefs.SetInt("isAdditionalTaken" + OperaNumber, isAdditionalTaken ? 1 : 0);
    }

    public void LoadOperaData()
    {
        isComplete = PlayerPrefs.GetInt("isComplete" + OperaNumber, 0) == 1;
        IsCompletedAtStart = PlayerPrefs.GetInt("IsCompletedAtStart" + OperaNumber, 0) == 1;
        isScanned = PlayerPrefs.GetInt("isScanned" + OperaNumber, 0) == 1;
        isAdditionalTaken = PlayerPrefs.GetInt("isAdditionalTaken" + OperaNumber, 0) == 1;
    }
}
