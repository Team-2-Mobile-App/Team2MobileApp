using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMissingObject : MonoBehaviour, IPointerClickHandler
{

    private Image _operaSprite;

    private OperaData _data;

    private void Awake()
    {
        _operaSprite = GetComponentInChildren<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.inventory.ObjectSelected = _data;
    }


    public void Setup(OperaData data)
    {
        _data = data;
        _operaSprite.sprite = data.operaInteractable.Additional.image.sprite;
    }
}
