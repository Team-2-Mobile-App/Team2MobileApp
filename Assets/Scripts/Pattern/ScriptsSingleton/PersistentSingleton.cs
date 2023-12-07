using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    public static T Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            if (!TryGetComponent<T>(out Instance))
            {
                Instance = gameObject.AddComponent<T>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }
}
