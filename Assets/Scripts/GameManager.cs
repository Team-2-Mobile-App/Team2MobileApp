using Palmmedia.ReportGenerator.Core.Parser.Analysis;
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
    public OperaData operaViewOpened;
    public bool isLoginActive;
    public bool isTutorialComplete;
    string LoginUsername;

    //[HideInInspector]
    public string lastAccount => PlayerPrefs.GetString("lastAccount");

    public void SaveAccountLogin(string username)
    {
        PlayerPrefs.SetString("lastAccount", username);
        LoginUsername = username;
    }

    public void DeleteLogin()
    {
        PlayerPrefs.DeleteKey("lastAccount");
        LoginUsername="";
    }

    protected override void Awake()
    {
        base.Awake();
        flowGame = GetComponentInChildren<FlowGameManger>();
        //PlayerPrefs.DeleteAll();
        SaveAccountLogin("Test");
        //DeletelastAccountUsername();
        //Da spostare nello state di account, al tasto logout togliere lastaccount e gestire apertura gioco da lastaccount
        if (PlayerPrefs.HasKey("lastAccount")) Debug.Log("account");
        else Debug.Log("no account");
        if (PlayerPrefs.HasKey(LoginUsername + "tutorial") && PlayerPrefs.GetInt(LoginUsername + "tutorial") == 1) isTutorialComplete = true;
        else isTutorialComplete=false;
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
        }
        if (inventory.MissingObjectList.Count > 0)
            inventory.DeleteDublicateObject();
    }
}
