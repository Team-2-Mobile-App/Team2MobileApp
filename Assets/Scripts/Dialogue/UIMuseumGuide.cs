using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMuseumGuide : MonoBehaviour
{

    [SerializeField] private GameObject TextSelection;
    public TextMeshProUGUI DialogueText;


    private void OnEnable()
    {
        ActionManager.OnDialogueStarts += ActivePanel;
    }


    public void ActivePanel(bool isActive)
    {
        TextSelection.SetActive(isActive);
    }



    private void OnDisable()
    {
        ActionManager.OnDialogueStarts -= ActivePanel;
    }

}
