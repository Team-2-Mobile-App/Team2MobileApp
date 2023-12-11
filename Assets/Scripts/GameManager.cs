using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : PersistentSingleton<GameManager>
{
    [HideInInspector]
    public FlowGameManger flowGame;


    public PlayerInventory inventory;
    public GameObject ShowOperaUIContainer;
    public bool isMovable;
    public GameObject OperaContainer;
    public List<OperaData> operaList = new List<OperaData>();
    public OperaData operaSelected;



    private void OnEnable()
    {
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
