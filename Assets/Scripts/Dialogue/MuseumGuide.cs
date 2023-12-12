using System.Collections.Generic;
using UnityEngine;

public class MuseumGuide : MonoBehaviour
{
    public List<Dialogue> Dialogues;
    public float TextSpeed;

    [HideInInspector]
    public DialoguesHandler m_dialoguesManager;



    private void Awake()
    {
        m_dialoguesManager = new DialoguesHandler(Dialogues);
    }

}
