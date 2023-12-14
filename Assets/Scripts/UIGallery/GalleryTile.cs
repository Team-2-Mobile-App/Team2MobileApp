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

    private UIManager _uiManager;

    OperaData operaData;

    private void OnEnable()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
    }

    private void Start()
    {
        
        operaImage.sprite = SetOperaImage();
    }
    public void FillData(OperaData opera)
    {
        operaData = opera;
    }

    private void SetOperaView()
    {
        _uiManager.title.text = operaData.operaData.OperaName;
        _uiManager.image.sprite = SetOperaImage();
        _uiManager.description.text = OperaDescription();
    }

    private string OperaDescription()
    {
        if (operaData.isScanned)
            return (operaData.operaData.Description1 + " " + operaData.operaData.Description2);
        else 
            return (operaData.operaData.Description1 + " " + _uiManager.missDescription);
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
        if (operaData.isScanned) _uiManager.ScanButton.gameObject.SetActive(false);
        else _uiManager.ScanButton.gameObject.SetActive(true);
    }

    private void OpenOperaView()
    {
        _uiManager.OpenOperaView();
        SetOperaView();
        ScanButtonRefresh();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (operaData.isComplete)
            OpenOperaView();
    }
}
