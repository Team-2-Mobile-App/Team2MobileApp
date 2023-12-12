using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuseumGuide : MonoBehaviour
{
    public List<Dialogue> Dialogues;
    public UIMuseumGuide UI;
    public float TextSpeed;

    protected DialoguesHandler m_dialoguesManager;
    protected bool m_runDialogue;
    protected int m_scriptLineIndex;
    protected float m_time;
    protected string m_scriptLineToPrint;
    protected string m_currentDialogueName;
    protected List<string> m_currentDialogue;


    private void Awake()
    {
        m_dialoguesManager = new(Dialogues);
        m_currentDialogue = new();
    }

    private void OnEnable()
    {
        ActionManager.OnDialogueStarts += TurnOnMuseumGuide;
    }

    private void Update()
    {
        HandlePrintProcess();

    }


    public void TurnOnMuseumGuide()
    {
        m_currentDialogue = m_dialoguesManager.GetDialogue(out m_currentDialogueName);
        m_scriptLineToPrint = m_currentDialogue[0];
        UI.DialogueText.text = "";
        m_scriptLineIndex = -1;
        m_time = 0;
        m_runDialogue = true;

    }



    private void CheckScriptLinePrintStatus()
    {
        if (m_scriptLineToPrint != null && m_scriptLineIndex == m_scriptLineToPrint.Length - 1)
        {
            m_scriptLineIndex = -1;
            m_time = 0f;
            m_scriptLineToPrint = null;
        }
    }


    private void PrintScriptLine()
    {
        if (m_scriptLineToPrint == null || UI.DialogueText.text == m_scriptLineToPrint) return;
        int time = (int)m_time;
        m_time += Time.deltaTime * TextSpeed;

        if (time < (int)m_time)
        {
            m_scriptLineIndex++;
            UI.DialogueText.text += m_currentDialogue[0][m_scriptLineIndex];
        }
    }


    private void LoadNextScriptLine()
    {
        if (IsNotTouching()) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began && m_scriptLineToPrint == null)
        {
            if (m_currentDialogue.Count > 1)
            {
                m_currentDialogue.Remove(m_currentDialogue[0]);
                m_scriptLineToPrint = m_currentDialogue[0];
                UI.DialogueText.text = "";
            }
            else if (m_currentDialogue.Count == 1) 
            { 
                m_runDialogue = false;
                GameManager.Instance.flowGame.StateMachine.ChangeState(GameManager.Instance.flowGame.NavigationState);
            }
        }
    }


    private void HandlePrintProcess()
    {
        if (m_runDialogue)
        {
            LoadNextScriptLine();
            PrintScriptLine();
            CheckScriptLinePrintStatus();
        }
    }


    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);

    }



    private void OnDisable()
    {
        ActionManager.OnDialogueStarts -= TurnOnMuseumGuide;
    }
}
