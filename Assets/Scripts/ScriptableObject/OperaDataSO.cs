using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/NewOpera")]
public class OperaDataSO : ScriptableObject
{
    //public OperaData MissingObject = null;
    public string OperaName;
    public string Description1;
    public string Description2;
    public string Description3;
    public Sprite OperaSprite;
}
