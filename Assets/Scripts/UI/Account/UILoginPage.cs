using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoginPage : MonoBehaviour
{
    [SerializeField] TMP_InputField userNameInputField, passwordInputField;
    [SerializeField] GameObject loginCanvas;
    [SerializeField] GameObject accountCreationgCanvas;
    [SerializeField] TMP_Text resultText;

    private void Start()
    {
        ResultTextPrompt("");
        accountCreationgCanvas.SetActive(false);
    }

    public void CreateCanvasButton()
    {
        ChangePlaceHolderText("Create Username", "Create Password");
        loginCanvas.SetActive(false);
        accountCreationgCanvas.SetActive(true);
        ResultTextPrompt("");
        ResetTextInput();
    }

    private void ChangePlaceHolderText(string username, string password)
    {
        var _userNamePlaceHolder = userNameInputField.placeholder;
        var _passwordPlaceHolder = passwordInputField.placeholder;
        _userNamePlaceHolder.gameObject.GetComponent<TextMeshProUGUI>().text = username;
        _passwordPlaceHolder.gameObject.GetComponent<TextMeshProUGUI>().text = password;
    }

    private void ResultTextPrompt(string text)
    {
        resultText.text = text;
        Invoke("DeleteText", 2f);
    }

    private void DeleteText()
    {
        resultText.text = "";
    }

    public void Login()
    {
        string tempUsername = userNameInputField.text;
        string tempPassword = passwordInputField.text;

        if (tempUsername != "" && tempUsername == PlayerPrefs.GetString(tempUsername + "Username") && tempPassword == PlayerPrefs.GetString(tempUsername + "Password"))
        {
            ResultTextPrompt("Successful Login");
            ResetTextInput();
            GameManager.Instance.flowGame.BackToGame();
            GameManager.Instance.SaveLoginState(tempUsername);
        }
        else
        {
            ResetTextInput();
            ResultTextPrompt("WRONG USERNAME OR PASSWORD");
        }
    }

    public void ConfirmAccountCreation()
    {
        string tempUsername = userNameInputField.text;
        string tempPassword = passwordInputField.text;
        if (tempUsername == "" || tempPassword == "" || tempUsername.Length < 4)
        {
            ResultTextPrompt("Error Username is too short (Greater Than 4 Characters).");
            ResetTextInput();
            tempUsername = "";
        }

        else if (tempUsername != "" && tempPassword != "" && GameManager.Instance.isUsernameValid(tempUsername))
        {
            ResultTextPrompt("Account Succesfully Created");
            GameManager.Instance.SaveAccountLogin(tempUsername, tempPassword);
            ChangePlaceHolderText("Enter Username...", "Enter Password...");
            ResetTextInput();
            loginCanvas.SetActive(true);
            accountCreationgCanvas.SetActive(false);
        }
        else if (tempUsername != "" && tempPassword != "" && !GameManager.Instance.isUsernameValid(tempUsername))
        {
            ResultTextPrompt("Error Username Exist.");
            ResetTextInput();
            tempUsername = "";
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
