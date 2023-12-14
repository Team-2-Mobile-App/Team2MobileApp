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
        PlayerPrefs.SetInt("isComplete", isComplete ? 1 : 0);
        PlayerPrefs.SetInt("IsCompletedAtStart", IsCompletedAtStart ? 1 : 0);
        PlayerPrefs.SetInt("isScanned", isScanned ? 1 : 0);
    }

    public void LoadOperaData()
    {
        isComplete = PlayerPrefs.GetInt("isComplete", 0) == 1;
        IsCompletedAtStart = PlayerPrefs.GetInt("IsCompletedAtStart", 0) == 1;
        isScanned = PlayerPrefs.GetInt("isScanned", 0) == 1;
    }
}
