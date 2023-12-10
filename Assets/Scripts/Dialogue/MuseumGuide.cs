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


  




}
