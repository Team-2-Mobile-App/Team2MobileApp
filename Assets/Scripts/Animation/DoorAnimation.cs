using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animator animator;

    public static Action<bool> OnOpenDoor;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        OnOpenDoor += OpenDoor;
    }

    public void OpenDoor(bool isOpen)
    {
        animator.SetBool("IsOpen", isOpen);
    }

    private void OnDisable()
    {
        OnOpenDoor -= OpenDoor;
    }


}
