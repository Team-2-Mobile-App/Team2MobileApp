using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueState : StateBase<FlowGameManger>
{

    protected List<string> m_currentDialogue;
    protected bool m_runDialogue;
    protected int m_scriptLineIndex;
    protected float m_time;
    protected string m_scriptLineToPrint;
    protected string m_currentDialogueName;
    

    public static event Action<string> OnWriteDialogue;
    public static event Action OnDialogueStarts;
    public static event Action OnDialogueEnds;

    public OnDialogueState(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {
        
    }



    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        OnDialogueStarts?.Invoke();

        ////se tutorial attivo 
        TurnOnMuseumGuide(contex);

        //if (!GameManager.Instance.operaSelected.IsCompletedAtStart)
        //GameManager.Instance.operaSelected.operaData.SetUpDialogue();
            //TurnOnOperaDialogue(GameManager.Instance.operaSelected);

    }


    public override void OnUpdate(FlowGameManger contex)
    {
        base.OnUpdate(contex);
        HandlePrintProcess(contex);
    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        OnDialogueEnds?.Invoke();
    }


    public void TurnOnMuseumGuide(FlowGameManger contex)
    {
        m_currentDialogue = contex.MuseumGuide.m_dialoguesManager.GetDialogue(out m_currentDialogueName);
        m_scriptLineToPrint = m_currentDialogue[0];
        OnWriteDialogue?.Invoke("");
        m_scriptLineIndex = -1;
        m_time = 0;
        m_runDialogue = true;

    }

    public void TurnOnOperaDialogue(OperaData data)
    {
        m_currentDialogue = data.operaData.m_dialoguesManager.GetDialogue(out m_currentDialogueName);
        Debug.Log(m_currentDialogue);
        m_scriptLineToPrint = m_currentDialogue[0];
        OnWriteDialogue?.Invoke("");
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


    private void PrintScriptLine(FlowGameManger contex)
    {
        if (m_scriptLineToPrint == null) return;
        int time = (int)m_time;
        m_time += Time.deltaTime * contex.MuseumGuide.TextSpeed;

        if (time < (int)m_time)
        {
            m_scriptLineIndex++;
            OnWriteDialogue?.Invoke(m_currentDialogue[0][m_scriptLineIndex].ToString());
        }
    }


    private void LoadNextScriptLine(FlowGameManger contex)
    {
        if (IsNotTouching()) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began && m_scriptLineToPrint == null)
        {
            if (m_currentDialogue.Count > 1)
            {
                m_currentDialogue.Remove(m_currentDialogue[0]);
                m_scriptLineToPrint = m_currentDialogue[0];
                OnWriteDialogue?.Invoke("");
            }
            else if (m_currentDialogue.Count == 1)
            {
                m_runDialogue = false;
                _stateMachine.ChangeState(contex.OnNavigationState);
            }
        }
    }


    private void HandlePrintProcess(FlowGameManger contex)
    {
        if (m_runDialogue)
        {
            LoadNextScriptLine(contex);
            PrintScriptLine(contex);
            CheckScriptLinePrintStatus();
        }
    }


    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);

    }



}
