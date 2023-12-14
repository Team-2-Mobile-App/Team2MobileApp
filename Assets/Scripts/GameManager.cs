using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// Non mi piace serve a michele
    /// </summary>
    [HideInInspector]
    public FlowGameManger flowGame;


    public PlayerInventory inventory;
    public GameObject ShowOperaUIContainer;
    public bool isMovable;
    public GameObject OperaContainer;
    public List<OperaData> operaList = new List<OperaData>();
    public OperaData operaSelected;

    protected override void Awake()
    {
        base.Awake();
        flowGame = GetComponentInChildren<FlowGameManger>();
        //PlayerPrefs.DeleteAll();
    }


    private void Start()
    {

        isMovable = true; // Da cambiare in futuro con caricare la scena o sostituire con gli stati
        if (OperaContainer != null)
        {
            OperaData[] OperaChildren = OperaContainer.GetComponentsInChildren<OperaData>();
            foreach (var item in OperaChildren)
            {
                item.LoadOperaData();
                if (item.isAdditionalTaken) inventory.Pickup(item);
                operaList.Add(item);
            }
            inventory.DeleteDublicateObject();
        }
    }


}
