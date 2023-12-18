using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueState : StateBase<FlowGameManger>
{

    private List<string> m_currentDialogue;
    private bool m_runDialogue;
    private int m_scriptLineIndex;
    private float m_time;
    private int index;
    

    public static event Action OnDialogueStarts;
    public static event Action OnDialogueEnds;

    public OnDialogueState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {
        
    }



    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        GameManager.Instance.isMovable = false;
        OnDialogueStarts?.Invoke();

        if (!GameManager.Instance.operaSelected.IsCompletedAtStart)
        {
            TurnOnOperaDialogue(GameManager.Instance.operaSelected, contex);
        }

        //if is museum guide TurnOnMuseumGuideDialogue();

    }


    public override void OnUpdate(FlowGameManger contex)
    {
        base.OnUpdate(contex);
        HandlePrintProcess(contex, GameManager.Instance.operaSelected);
    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        GameManager.Instance.isMovable = true;
        OnDialogueEnds?.Invoke();
    }


    public void TurnOnMuseumGuideDialogue(FlowGameManger contex)
    {
        m_currentDialogue = contex.MuseumGuide.dialogues;
        Debug.Log(m_currentDialogue.Count);
        contex.MuseumGuide.UIMuseum._dialogueText.text = "";
        m_runDialogue = true;
        index = 0;
        m_time = 0;
        m_scriptLineIndex = 0;
    }


    public void TurnOnOperaDialogue(OperaData data,FlowGameManger contex)
    {
        m_currentDialogue = data.operaData.dialogues;
        Debug.Log(m_currentDialogue.Count);
        contex.MuseumGuide.UIMuseum._dialogueText.text = "";
        m_runDialogue = true;
        index = 0;
        m_time = 0;
        m_scriptLineIndex = 0;
    }


    private void CheckScriptLinePrintStatus(FlowGameManger contex, OperaData data)
    {
        string message = data.operaData.DialogueName + " : " + m_currentDialogue[index];

        if (m_scriptLineIndex == message.Length)
        {
            if (IsNotTouching()) return;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (index == m_currentDialogue.Count - 1) contex.StateMachine.ChangeState(contex.OnNavigationState);
                else
                {
                    contex.MuseumGuide.UIMuseum._dialogueText.text = "";
                    m_scriptLineIndex = 0;
                    index++;
                }
            }
        }
        
    }

    
    
    private void PrintScriptLine(FlowGameManger contex, OperaData data)
    {
        string message = data.operaData.DialogueName + " : " + m_currentDialogue[index];
        int time =  (int) m_time;
        m_time += Time.deltaTime * contex.MuseumGuide.TextSpeed;
        if (m_scriptLineIndex == message.Length) return;
        if (time < (int)m_time)
        {
            contex.MuseumGuide.UIMuseum._dialogueText.text += message[m_scriptLineIndex];
            m_scriptLineIndex ++;
        }

    }


    private void HandlePrintProcess(FlowGameManger contex,OperaData opera)
    {
        if (m_runDialogue)
        {
            CheckScriptLinePrintStatus(contex, opera);
            PrintScriptLine(contex, opera);
        }
    }

    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);


    }



}
