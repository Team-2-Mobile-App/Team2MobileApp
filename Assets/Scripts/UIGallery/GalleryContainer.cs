using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalleryContainer : MonoBehaviour
{
    private List<OperaData> operaDataList;
    public GameObject GalleryTilePrefab;
    public GameObject GalleryOperaView;

    [Header("Opera View")]
    public TextMeshProUGUI title;
    public Image image;
    public TextMeshProUGUI description;
    public string missDescription;
    public Button closeButton;
    public Button ScanButton;

    private void OnEnable()
    {
        FillContainer();
    }
    private void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    private void Awake()
    {
        operaDataList = GameManager.Instance.operaList;
        //FillContainer();
    }
    private void FillContainer()
    {
        for (int i = 0; i < operaDataList.Count; i++)
        {
            var opera = Instantiate(GalleryTilePrefab, this.gameObject.transform);
            OperaData operaData = operaDataList[i];
            GalleryTile gallery = opera.GetComponent<GalleryTile>();
            FillOperaData(operaData, gallery);
        }
    }

    private void FillOperaData(OperaData operaData, GalleryTile gallery)
    {
        gallery.FillData(operaData);
    }

    public void OpenOperaView()
    {
        GalleryOperaView.SetActive(true);
    }

    private void CloseOperaView()
    {
        GalleryOperaView.SetActive(false);
        title = null;
        image.sprite = null;
        description = null;
    }
}
