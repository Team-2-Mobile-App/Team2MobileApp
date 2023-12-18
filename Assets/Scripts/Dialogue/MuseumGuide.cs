using System.Collections.Generic;
using UnityEngine;

public class MuseumGuide : MonoBehaviour
{
    public float TextSpeed;

    public string DialogueName;
    public List<string> dialogues;

    [HideInInspector] public UIMuseumGuide UIMuseum;

    private void Awake()
    {
        UIMuseum = GetComponent<UIMuseumGuide>();
    }



}
