using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDialogueMuseumGuide : StateBase<FlowGameManger>
{

    private List<string> m_currentDialogue;
    private bool m_runDialogue;
    private int m_scriptLineIndex;
    private float m_time;
    private int index;


    public OnDialogueMuseumGuide(string stateID, StatesMachine<FlowGameManger> statesMachine) : base(stateID, statesMachine)
    {

    }


    public override void OnEnter(FlowGameManger contex)
    {
        base.OnEnter(contex);
        OnDialogueOperaState.OnDialogueStarts?.Invoke();
        TurnOnMuseumGuideDialogue(contex);
        //SoundManager.OnPlayMusicPuppetDialogue?.Invoke();
    }


    public override void OnUpdate(FlowGameManger contex)
    {
        base.OnUpdate(contex);
        HandlePrintProcess(contex, GameManager.Instance.operaSelected);
    }

    public override void OnExit(FlowGameManger contex)
    {
        base.OnExit(contex);
        OnDialogueOperaState.OnDialogueEnds?.Invoke();
        GameManager.Instance.TutorialComplete();
    }

    public void TurnOnMuseumGuideDialogue(FlowGameManger contex)
    {
        m_currentDialogue = new List<string>();
        m_currentDialogue = contex.MuseumGuide.dialogues;
        contex.MuseumGuide.UIMuseum._dialogueText.text = "";
        m_runDialogue = true;
        index = 0;
        m_time = 0;
        m_scriptLineIndex = 0;
    }


    private void CheckScriptLinePrintStatusForOpera(FlowGameManger contex)
    {
        string message = contex.MuseumGuide.DialogueName + " : " + m_currentDialogue[index];

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



    private void PrintScriptLine(FlowGameManger contex)
    {
        string message = contex.MuseumGuide.DialogueName + " : " + m_currentDialogue[index];
        int time = (int)m_time;
        m_time += Time.deltaTime * contex.MuseumGuide.TextSpeed;
        if (m_scriptLineIndex == message.Length) return;
        if (time < (int)m_time)
        {
            contex.MuseumGuide.UIMuseum._dialogueText.text += message[m_scriptLineIndex];
            m_scriptLineIndex++;
        }

    }


    private void HandlePrintProcess(FlowGameManger contex, OperaData opera)
    {
        if (m_runDialogue)
        {
            CheckScriptLinePrintStatusForOpera(contex);
            PrintScriptLine(contex);
        }
    }

    public bool IsNotTouching()
    {
        return (Input.touchCount <= 0);


    }

}
