using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMuseumGuide : MonoBehaviour
{

    [SerializeField] private GameObject _textSelection;
    public TextMeshProUGUI _dialogueText;

    private void OnEnable()
    {
        OnDialogueState.OnDialogueStarts += ActivePanel;
        OnDialogueState.OnDialogueEnds += DisactivePanel;

    }


    private void ActivePanel()
    {
        _textSelection.SetActive(true);
    }

    private void DisactivePanel()
    {
        _textSelection.SetActive(false);
    }



    private void OnDisable()
    {
        OnDialogueState.OnDialogueStarts -= ActivePanel;
        OnDialogueState.OnDialogueEnds -= DisactivePanel;

    }

}
