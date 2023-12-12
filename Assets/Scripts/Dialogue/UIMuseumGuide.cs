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
        ActionManager.OnDialogueEnds += DisactivePanel;
    }


    public void ActivePanel()
    {
        TextSelection.SetActive(true);
    }

    public void DisactivePanel()
    {
        TextSelection.SetActive(false);
    }

    private void OnDisable()
    {
        ActionManager.OnDialogueStarts -= ActivePanel;
        ActionManager.OnDialogueEnds -= DisactivePanel;
    }

}
