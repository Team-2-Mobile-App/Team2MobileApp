using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PauseButton;

    public GameObject PanelPause;



    public void EnablePoseMenu()
    {
        PanelPause.SetActive(true);
    }

}
