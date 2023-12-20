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

    public void TransferSaveOperaData(string newUsername)
    {
        PlayerPrefs.SetInt(newUsername + "isComplete" + OperaNumber, isComplete ? 1 : 0);
        PlayerPrefs.SetInt(newUsername + "IsCompletedAtStart" + OperaNumber, IsCompletedAtStart ? 1 : 0);
        PlayerPrefs.SetInt(newUsername + "isScanned" + OperaNumber, isScanned ? 1 : 0);
        PlayerPrefs.SetInt(newUsername + "isAdditionalTaken" + OperaNumber, isAdditionalTaken ? 1 : 0);
    }

    public void SaveOperaData()
    {
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "isComplete" + OperaNumber, isComplete ? 1 : 0);
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "IsCompletedAtStart" + OperaNumber, IsCompletedAtStart ? 1 : 0);
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "isScanned" + OperaNumber, isScanned ? 1 : 0);
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "isAdditionalTaken" + OperaNumber, isAdditionalTaken ? 1 : 0);
    }

    public void ResetOperaData()
    {
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "isComplete" + OperaNumber, 0);
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "IsCompletedAtStart" + OperaNumber, 0);
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "isScanned" + OperaNumber, 0);
        PlayerPrefs.SetInt(GameManager.Instance.LoginUsername + "isAdditionalTaken" + OperaNumber, 0);
    }

    public void LoadOperaData()
    {
        isComplete = PlayerPrefs.GetInt(GameManager.Instance.LoginUsername + "isComplete" + OperaNumber, 0) == 1;
        IsCompletedAtStart = PlayerPrefs.GetInt(GameManager.Instance.LoginUsername + "IsCompletedAtStart" + OperaNumber, 0) == 1;
        isScanned = PlayerPrefs.GetInt(GameManager.Instance.LoginUsername + "isScanned" + OperaNumber, 0) == 1;
        isAdditionalTaken = PlayerPrefs.GetInt(GameManager.Instance.LoginUsername + "isAdditionalTaken" + OperaNumber, 0) == 1;
    }
}
