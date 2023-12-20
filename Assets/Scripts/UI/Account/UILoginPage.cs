using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILoginPage : MonoBehaviour
{
    [SerializeField] TMP_InputField userNameInputField, passwordInputField;
    [SerializeField] GameObject loginCanvas;
    [SerializeField] GameObject accountCreationgCanvas;
    [SerializeField] TMP_Text resultText;
    private string username = null;
    private string password = null;

    private void Start()
    {
        DebugTextPrompt("");
        accountCreationgCanvas.SetActive(false);
    }

    public void CreateCanvasButton()
    {
        ChangePlaceHolderText("Create Username", "Create Password");
        loginCanvas.SetActive(false);
        accountCreationgCanvas.SetActive(true);
        DebugTextPrompt("");
        ResetTextInput();
        username = null;
        password = null;
    }

    private void ChangePlaceHolderText(string username, string password)
    {
        var _userNamePlaceHolder = userNameInputField.placeholder;
        var _passwordPlaceHolder = passwordInputField.placeholder;
        _userNamePlaceHolder.gameObject.GetComponent<TextMeshProUGUI>().text = username;
        _passwordPlaceHolder.gameObject.GetComponent<TextMeshProUGUI>().text = password;
    }

    private void DebugTextPrompt(string text)
    {
        resultText.text = text;
    }

    public void GetUserName()
    {
        username = userNameInputField.text;
    }

    public void GetPassword()
    {
        password = passwordInputField.text;
    }

    public void Login()
    {
        string tempUsername = userNameInputField.text;
        string tempPassword = passwordInputField.text;

        if (tempUsername == PlayerPrefs.GetString(tempUsername + "Username") && tempPassword == PlayerPrefs.GetString(tempUsername + "Password"))
        {
            DebugTextPrompt("Successful Login");
            GameManager.Instance.SaveLoginState(tempUsername);
        }
        else
        {
            ResetTextInput();
            DebugTextPrompt("WRONG USERNAME OR PASSWORD");
        }
    }

    public void ConfirmAccountCreation()
    {

        if (username == null || password == null || username.Length < 4)
        {
            DebugTextPrompt("Error Username is too short (Greater Than 4 Characters).");
            ResetTextInput();
            username = null;
        }

        else if (username != null && password != null)
        {
            DebugTextPrompt("Account Succesfully Created");
            GameManager.Instance.SaveAccountLogin(username, password);
            ChangePlaceHolderText("Enter Username...", "Enter Password...");
            ResetTextInput();
            loginCanvas.SetActive(true);
            accountCreationgCanvas.SetActive(false);
        }
    }

    public void LoginCanvasButton()
    {
        ChangePlaceHolderText("Enter Username...", "Enter Password...");
        ResetTextInput();
        loginCanvas.SetActive(true);
        accountCreationgCanvas.SetActive(false);

    }

    private void ResetTextInput()
    {
        userNameInputField.text = "";
        passwordInputField.text = "";
    }
}
