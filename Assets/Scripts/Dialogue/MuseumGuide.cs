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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerInventory PlayerInventory) && !GameManager.Instance.isTutorialComplete)
        {
            GameManager.Instance.flowGame.StateMachine.ChangeState(GameManager.Instance.flowGame.OnDialogueMuseumGuide);
        }
    }
}
