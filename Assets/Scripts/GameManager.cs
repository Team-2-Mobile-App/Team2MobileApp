using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public FlowGameManger flowGame;


    public PlayerInventory inventory;
    public GameObject ShowOperaUIContainer;
    public bool isMovable;
    public GameObject OperaContainer;
    public List<OperaData> operaList = new List<OperaData>();
    public OperaData operaSelected;

    public static GameManager Instance;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            if (!TryGetComponent<GameManager>(out Instance))
            {
                Instance = gameObject.AddComponent<GameManager>();
            }
        }
        else
        {
            Destroy(gameObject);
        }

        flowGame = GetComponentInChildren<FlowGameManger>();
    }



    private void Start()
    {
        isMovable = true; // Da cambiare in futuro con caricare la scena o sostituire con gli stati
        if (OperaContainer != null)
        {
            OperaData[] OperaChildren = OperaContainer.GetComponentsInChildren<OperaData>();
            foreach (var item in OperaChildren)
            {
                operaList.Add(item);
            }
        }
    }

}
