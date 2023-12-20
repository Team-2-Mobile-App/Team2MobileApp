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
    public bool isLoginActive => PlayerPrefs.GetInt("lastLogin", 0) == 1;
    public bool isTutorialComplete => PlayerPrefs.GetInt(LoginUsername + "Tutorial", 0) == 1;
    public string LoginUsername;

    //[HideInInspector]
    public string lastAccount => PlayerPrefs.GetString("lastAccount");

    /// <summary>
    /// Salva utenti
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public void SaveAccountLogin(string username, string password)
    {        
        PlayerPrefs.SetString(username + "Username", username);
        PlayerPrefs.SetString(username + "Password", password);
    }

    /// <summary>
    /// Salva username nel gamemanager e se lo ricorda per prossima apertura dell'app
    /// </summary>
    /// <param name="username"></param>
    public void SaveLoginState(string username)
    {
        PlayerPrefs.SetString("lastAccount", username);
        LoginUsername = username;
        PlayerPrefs.SetInt("lastLogin", 1);
    }

    /// <summary>
    /// Per uscire dall'account così da rivedere il login page
    /// </summary>
    public void DeleteLogin()
    {
        PlayerPrefs.DeleteKey("lastAccount");
        LoginUsername="";
        PlayerPrefs.SetInt("lastLogin", 0);
    }

    /// <summary>
    /// Da usare per sapere se far partire il tutorial alla prima apertura in navigation state
    /// </summary>
    public void TutorialComplete()
    {
        PlayerPrefs.SetInt(LoginUsername + "Tutorial", 1);
    }

    protected override void Awake()
    {
        base.Awake();
        flowGame = GetComponentInChildren<FlowGameManger>();
        //PlayerPrefs.DeleteAll();
        //DeletelastAccountUsername();
        //Da spostare nello state di account, al tasto logout togliere lastaccount e gestire apertura gioco da lastaccount
        //if (PlayerPrefs.HasKey("lastAccount") && isLoginActive) Debug.Log("account");
        //else Debug.Log("no account");
        //if (PlayerPrefs.HasKey(LoginUsername + "tutorial") && PlayerPrefs.GetInt(LoginUsername + "tutorial") == 1) isTutorialComplete = true;
        //else isTutorialComplete=false;
        //SaveAccountLogin("testlastaccount1");
        //Debug.Log(lastAccount);
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
