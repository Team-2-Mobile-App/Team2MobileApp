using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMuseumGuide : MonoBehaviour
{

    [SerializeField] private GameObject TextSelection;
    public TextMeshProUGUI DialogueText;
    


    public void ActiveGameObject(bool isActive)
    {
        TextSelection.SetActive(isActive);
    }



}
