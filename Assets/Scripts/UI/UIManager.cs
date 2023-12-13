using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button PauseButton;

    public Image MapImage;
    public Button Gallery;
    public Button Game;
    public Button Map;
    public Button Account;

    public GameObject PanelPause;

    private void Awake()
    {
        operaDataList = GameManager.Instance.operaList;
    }

    public void EnablePoseMenu(bool isActivate)
    {
        PanelPause.SetActive(isActivate);
        MapImage.gameObject.SetActive(true);
    }



    public GameObject GalleryConteiner;

    [Header("Opera View")]
    public TextMeshProUGUI title;
    public Image image;
    public TextMeshProUGUI description;
    public string missDescription;
    public Button closeButton;
    public Button ScanButton;
    public GameObject GalleryTile;
    public GameObject GalleryPanel;

   

    public void CloseGalleryPanel()
    {
        foreach (Transform child in GalleryConteiner.transform)
        {
            Destroy(child.gameObject);
        }
    }
    private List<OperaData> operaDataList;

    public void FillContainer()
    {
        for (int i = 0; i<operaDataList.Count; i++)
        {
            var opera = Instantiate(GalleryTile, GalleryConteiner.gameObject.transform);
            OperaData operaData = operaDataList[i];
            GalleryTile gallery = opera.GetComponent<GalleryTile>();
            gallery.FillData(operaData);
        }
    }

    public GameObject GalleryOperaView;
    public void OpenOperaView()
    {
        GalleryOperaView.SetActive(true);
    }

    public void CloseOperaView()
    {
        GalleryOperaView.SetActive(false);
        
    }
}
