using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMuseumGuide : MonoBehaviour
{

    [SerializeField] private GameObject _textSelection;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    private void OnEnable()
    {
        OnDialogueState.OnDialogueStarts += ActivePanel;
        OnDialogueState.OnDialogueEnds += DisactivePanel;
        OnDialogueState.OnWriteDialogue += SetDialogueTest;
    }


    private void ActivePanel()
    {
        _textSelection.SetActive(true);
    }

    private void DisactivePanel()
    {
        _textSelection.SetActive(false);
    }


    private void SetDialogueTest(string dialogueTest)
    {
        //Debug.Log(dialogueTest);
        if (dialogueTest == "") _dialogueText.text = dialogueTest;
        else _dialogueText.text += dialogueTest;
    }

    private void OnDisable()
    {
        OnDialogueState.OnDialogueStarts -= ActivePanel;
        OnDialogueState.OnDialogueEnds -= DisactivePanel;
        OnDialogueState.OnWriteDialogue -= SetDialogueTest;
    }

}
