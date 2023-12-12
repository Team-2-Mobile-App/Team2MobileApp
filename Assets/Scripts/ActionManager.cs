using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionManager 
{
    public static Action<float, float> OnTouchStay;

    public static Action<float, float> OnTouchMove;

    public static Action OnDialogueStarts;
    public static Action OnDialogueEnds;

}
