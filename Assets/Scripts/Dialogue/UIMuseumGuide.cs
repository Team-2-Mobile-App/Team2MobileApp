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
        OnDialogueState.OnDialogueStarts += ActivePanel;
        OnDialogueState.OnDialogueEnds += DisactivePanel;
        OnDialogueState.OnWriteDialogue += SetDialogueTest;
    }


    private void ActivePanel()
    {
        TextSelection.SetActive(true);
    }

    private void DisactivePanel()
    {
        TextSelection.SetActive(false);
    }


    private void SetDialogueTest(string dialogueTest)
    {
        //Debug.Log(dialogueTest);
        if (dialogueTest == "") DialogueText.text = dialogueTest;
        else DialogueText.text += dialogueTest;
    }

    private void OnDisable()
    {
        OnDialogueState.OnDialogueStarts -= ActivePanel;
        OnDialogueState.OnDialogueEnds -= DisactivePanel;
        OnDialogueState.OnWriteDialogue -= SetDialogueTest;
    }

}
