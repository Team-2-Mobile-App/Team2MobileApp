using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAccountPage : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] GameObject mainCanvas;
    [SerializeField] TMP_Text currentUsername;
    [Header("Settings")]
    [SerializeField] GameObject settingsCanvas;
    [SerializeField] TMP_InputField changeUsernameInputField, oldPasswordInputField, newPasswordInputField, checkNewPasswordInputField;
    [SerializeField] TMP_Text resultChangeText;
    [Header("Ticket")]
    [SerializeField] GameObject ticketCanvas;
    [SerializeField] Image LockTicket;
    [SerializeField] string ticketCode;
    [SerializeField] TMP_Text ticketText;
    [SerializeField] TMP_Text resultCopyText;

    private bool isPasswordRight, isUsernameRight;

    private void OnEnable()
    {
        //set canvas
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        ticketCanvas.SetActive(false);
        //set lock ticket
        if (GameManager.Instance.isGameComplete) LockTicket.gameObject.SetActive(false);
        else LockTicket.gameObject.SetActive(true);
        //set username
        currentUsername.text = GameManager.Instance.LoginUsername;
        //set ticket
        ticketText.text = ticketCode;
        //delete extra text
        DeleteText();
    }

    private void DeleteText()
    {
        resultChangeText.text = "";
        resultCopyText.text = "";
    }
    public void ButtonCopyTicketCode()
    {
        GUIUtility.systemCopyBuffer = ticketCode;
        resultCopyText.text = "Copied to Clipboard";
        Invoke("DeleteText", 2f);
    }

    public void ButtonOpenTicketPanel()
    {
        if (mainCanvas.activeInHierarchy) mainCanvas.SetActive(false);
        if (settingsCanvas.activeInHierarchy) settingsCanvas.SetActive(false);
        ticketCanvas.SetActive(true);
    }

    public void ButtonOpenMainPanel()
    {
        if (ticketCanvas.activeInHierarchy) ticketCanvas.SetActive(false);
        if (settingsCanvas.activeInHierarchy) settingsCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    public void ButtonOpenSettingsPanel()
    {
        if (ticketCanvas.activeInHierarchy) ticketCanvas.SetActive(false);
        if (mainCanvas.activeInHierarchy) mainCanvas.SetActive(false);
        ResetTextInput();
        settingsCanvas.SetActive(true);
    }

    public void ButtonLogout()
    {
        //Tornare al login state
        GameManager.Instance.DeleteLastLogin();
        GameManager.Instance.flowGame.GoToLogin();
    }

    public void ButtonSaveAccountChanges()
    {
        string tempNewUsername = changeUsernameInputField.text;
        string tempOldPassword = oldPasswordInputField.text;
        string tempNewPassword = newPasswordInputField.text;
        string tempCheckNewPassword = checkNewPasswordInputField.text;
        if (tempNewUsername != "" || tempOldPassword != "" || tempNewPassword != "" || tempCheckNewPassword != "")
        {
            //solo se non esiste già lo stesso username
            if (tempNewUsername == "" && tempOldPassword != "" && tempNewPassword != "" && tempCheckNewPassword != "")
            {
                NewPassword(tempOldPassword, tempNewPassword, tempCheckNewPassword);
                ResetTextInput();
                Invoke("DeleteText", 2f);
                return;
            }
            if (tempNewUsername != "" && tempOldPassword != "" && tempNewPassword == "" && tempCheckNewPassword == "")
            {
                NewUsername(tempNewUsername, tempOldPassword);
                ResetTextInput();
                Invoke("DeleteText", 2f);
                return;
            }
            if (tempNewUsername != "" && tempOldPassword != "" && tempNewPassword != "" && tempCheckNewPassword != "")
            {
                isPasswordRight = false;
                isUsernameRight = false;
                NewUsername(tempNewUsername, tempOldPassword);
                NewPassword(tempOldPassword, tempNewPassword, tempCheckNewPassword);
                if (isPasswordRight && isUsernameRight) resultChangeText.text = "Username and Password Changed";
                ResetTextInput();
                Invoke("DeleteText", 2f);
                return;
            }
        }else resultChangeText.text = "Nothing Changed";
        ResetTextInput();
        Invoke("DeleteText", 2f);
    }

    private void NewUsername(string newUsername, string oldPassword)
    {
        if (!GameManager.Instance.isUsernameValid(newUsername)) resultChangeText.text = "Username Exist";
        else if (GameManager.Instance.isSamePassword(oldPassword)) 
        {
            GameManager.Instance.ChangeUsername(newUsername);
            resultChangeText.text = "Username Updated";
        } 
        else resultChangeText.text = "Wrong Password";
        currentUsername.text = GameManager.Instance.LoginUsername;
    }

    private void NewPassword(string oldPass, string newPass, string checkNewPass)
    {
        if (!GameManager.Instance.isSamePassword(oldPass)) resultChangeText.text = "Wrong Password";
        else if (newPass == checkNewPass)
        {
            GameManager.Instance.ChangePassword(newPass);
            resultChangeText.text = "Password Changed"; 
        }
        else resultChangeText.text = "New Password Mismatch";
    }

    private void ResetTextInput()
    {
        changeUsernameInputField.text = "";
        oldPasswordInputField.text = "";
        newPasswordInputField.text = "";
        checkNewPasswordInputField.text = ""; ;
    }
}
