using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public bool isGameComplete
    {
        get
        {
            bool complete = true;
            foreach (OperaData opera in operaList)
            {
                if (!opera.isComplete) complete = false;
            }
            return complete;
        }
    }
    //profilo in uso
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
        PlayerPrefs.SetInt("lastLogin", 1);
    }

    /// <summary>
    /// Per uscire dall'account così da rivedere il login page
    /// </summary>
    public void DeleteLastLogin()
    {
        PlayerPrefs.DeleteKey("lastAccount");
        LoginUsername = "";
        PlayerPrefs.SetInt("lastLogin", 0);
        inventory.RemoveAllFromInventory();
    }

    /// <summary>
    /// Da usare per quando cambio username per evitare che rifacendo un account con lo stesso nome usa quei salvataggi
    /// </summary>
    public void ChangeUsername(string username)
    {
        PlayerPrefs.SetString(username + "Password", PlayerPrefs.GetString(LoginUsername + "Password"));
        foreach (OperaData opera in operaList)
        {
            opera.TransferSaveOperaData(username);
        }
        foreach (OperaData opera in operaList)
        {
            opera.ResetOperaData();
        }
        PlayerPrefs.DeleteKey(LoginUsername + "Username");
        PlayerPrefs.DeleteKey(LoginUsername + "Password");
        SaveLoginState(username);
    }

    public void ChangePassword(string password)
    {
        PlayerPrefs.SetString(LoginUsername + "Password", password);
    }

    public bool isSamePassword(string password)
    {
        if (password == PlayerPrefs.GetString(LoginUsername + "Password")) return true;
        else return false;
    }

    public bool isUsernameValid(string username)
    {
        if (PlayerPrefs.HasKey(username + "Username")) return false;
        else return true;
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

    public void LoadAllData()
    {
        LoginUsername = lastAccount;
        isMovable = true; 
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

