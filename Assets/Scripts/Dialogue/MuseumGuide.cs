using System.Collections.Generic;
using UnityEngine;

public class MuseumGuide : MonoBehaviour
{
    [HideInInspector] public bool isMuseumGuide;

    public float TextSpeed;

    public string DialogueName;
    public List<string> dialogues;

    [HideInInspector] public UIMuseumGuide UIMuseum;

    private void Awake()
    {
        UIMuseum = GetComponent<UIMuseumGuide>();
    }


    private void OnTriggerEnter(Collider other)
    {
        isMuseumGuide = true;
        GameManager.Instance.flowGame.StateMachine.ChangeState(GameManager.Instance.flowGame.OnDialogueState);
    }

}
