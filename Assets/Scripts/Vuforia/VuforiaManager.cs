using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuforiaManager : MonoBehaviour
{
    public GameObject Vuforia;


    private void OnEnable()
    {
        OnScanState.ActiveVuforia += OnVuforiaEnabled;
    }


    private void OnVuforiaEnabled(bool isActive) => Vuforia.gameObject.SetActive(isActive);


    private void OnDisable()
    {
        OnScanState.ActiveVuforia -= OnVuforiaEnabled;
    }
}
