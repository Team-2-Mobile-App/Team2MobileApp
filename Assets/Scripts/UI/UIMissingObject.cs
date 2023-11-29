using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMissingObject : MonoBehaviour
{

    [SerializeField] private Image _operaSprite;

    private OperaData _data;


    public void Setup(OperaData data)
    {
        this._data = data;
        _operaSprite.sprite = data.MissingObject;

    }




}
