using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{

    public static T Instance;

    protected virtual void Awake()
    {
        if(Instance == null)
        {
            if(!TryGetComponent<T>(out Instance))
            {
                Instance = gameObject.AddComponent<T>();
            }
        }else
        {
            Destroy(gameObject);
        }
    }
}
