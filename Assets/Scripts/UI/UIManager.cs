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

   

    public void EnablePoseMenu(bool isActivate)
    {
        PanelPause.SetActive(isActivate);
        MapImage.gameObject.SetActive(true);
    }




    [Header("Opera View")]
    public TextMeshProUGUI title;
    public Image image;
    public TextMeshProUGUI description;
    public string missDescription;
    public Button closeButton;
    public Button ScanButton;

    [Header("ShowGallery")]
    public GameObject GalleryConteiner;
    public GameObject GalleryTile;
    public GameObject GalleryPanel;

    private List<OperaData> operaDataList => GameManager.Instance.operaList;
   

    public void CloseGalleryPanel()
    {
        foreach (Transform child in GalleryConteiner.transform)
        {
            Destroy(child.gameObject);
        }
    }

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
