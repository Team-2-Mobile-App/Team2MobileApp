using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILoginPage : MonoBehaviour
{
    [SerializeField] TMP_InputField userNameInputField, passwordInputField;
    [SerializeField] GameObject loginCanvas;
    [SerializeField] GameObject accountCreationgCanvas;
    [SerializeField] TMP_Text debugText;
    private string userName = null;
    private string password = null;

    private void Start()
    {
        DebugTextPrompt("");
        accountCreationgCanvas.SetActive(false);
    }

    public void CreateAccountButton()
    {
        ChangePlaceHolderText("Create Username", "Create Password");
        loginCanvas.SetActive(false);
        accountCreationgCanvas.SetActive(true);
        DebugTextPrompt("");
        ResetTextInput();
        userName = null;
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
        debugText.text = text;
    }

    public void GetUserName()
    {
        userName = userNameInputField.text;
    }

    public void GetPassword()
    {
        password = passwordInputField.text;
    }

    public void Login()
    {
        string tempUsername = userNameInputField.text;
        string tempPassword = passwordInputField.text;

        if (tempPassword.Equals(password) && tempUsername.Equals(userName))
        {
            DebugTextPrompt("Successful Login");
        }
        else
        {
            ResetTextInput();
            DebugTextPrompt("WRONG USERNAME OR PASSWORD");
        }
    }

    public void ConfirmAccountCreation()
    {

        if (userName.Length < 4)
        {
            DebugTextPrompt("Error Username is too short (Greater Than 4 Characters).");
            ResetTextInput();
            userName = null;
        }

        else if (userName != null && password != null)
        {
            DebugTextPrompt("Account Succesfully Created");
            ChangePlaceHolderText("Enter Username...", "Enter Password...");
            ResetTextInput();
            Debug.Log($"{userName},{password}");
            loginCanvas.SetActive(true);
            accountCreationgCanvas.SetActive(false);
        }
    }

    public void CancelButton()
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
