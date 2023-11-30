using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMissingObject : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private Image _operaSprite;

    private OperaData _data;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.inventory.ObjectSelected = _data;
    }

    public void Setup(OperaData data)
    {
        this._data = data;
        _operaSprite.sprite = data.operaInteractable.Additional.image.sprite;
    }
}
