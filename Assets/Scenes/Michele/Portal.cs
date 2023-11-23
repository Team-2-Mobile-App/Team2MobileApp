using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Target Position")]
    public Transform TargetPosition;

    private Vector3 newPosition;

    private void Start()
    {
        newPosition = TargetPosition.position;
    }

    public void MoveToNewPosition(Transform transform)
    {
        transform.position = new Vector3(newPosition.x,transform.position.y, newPosition.z);
    }
}
