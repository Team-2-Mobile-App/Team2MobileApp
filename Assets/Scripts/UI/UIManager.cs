using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PauseButton;

    public Button Gallery;
    public Button Game;
    public Button Map;
    public Button Account;

    public GameObject PanelPause;

  

    public void EnablePoseMenu(bool isActivate)
    {
        PanelPause.SetActive(isActivate);
    }

}
