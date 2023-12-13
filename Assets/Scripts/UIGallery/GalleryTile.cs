using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GalleryTile : MonoBehaviour, IPointerClickHandler
{
    public Image operaImage;
    public Image operaLock;

    private GalleryContainer galleryContainer;

    OperaData operaData;

    //private void OnEnable()
    //{
    //    operaImage.sprite = SetOperaImage();
    //}

    private void Start()
    {
        galleryContainer = GetComponentInParent<GalleryContainer>();
        operaImage.sprite = SetOperaImage();
    }
    public void FillData(OperaData opera)
    {
        operaData = opera;
    }

    private void SetOperaView()
    {
        galleryContainer.title.text = operaData.name;
        galleryContainer.image.sprite = SetOperaImage();
        galleryContainer.description.text = OperaDescription();
    }

    private string OperaDescription()
    {
        if (operaData.isScanned)
            return (operaData.operaData.Description1 + " " + operaData.operaData.Description2);
        else 
            return (operaData.operaData.Description1 + " " + galleryContainer.missDescription);
    }

    private Sprite SetOperaImage()
    {
        if (operaData.isComplete && operaData.isScanned)
        {
            operaLock.gameObject.SetActive(false);            
            return operaData.operaData.OperaSpriteScanned;
        }
        else if (operaData.isComplete && !operaData.isScanned)
        {
            operaLock.gameObject.SetActive(false);            
            return operaData.operaData.OperaSpriteGrey;
        }
        else
        {
            operaLock.gameObject.SetActive(true);
            return null;
        }
    }

    private void ScanButtonRefresh()
    {
        if (operaData.isScanned) galleryContainer.ScanButton.gameObject.SetActive(false);
        else galleryContainer.ScanButton.gameObject.SetActive(true);
    }

    private void OpenOperaView()
    {
        galleryContainer.OpenOperaView();
        SetOperaView();
        ScanButtonRefresh();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OpenOperaView();
    }
}
