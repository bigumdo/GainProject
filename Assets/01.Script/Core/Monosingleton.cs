using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monosingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool IsDestroyed = false;

    public static T Instance
    {
        get
        {
            if (IsDestroyed)
                _instance = null;
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if(_instance == null)
                {
                    Debug.LogError("¾ø¾î");
                }
                else
                {
                    IsDestroyed = false;
                }
            }
            return _instance;
        }
    }

    private void OnDestroy()
    {
        IsDestroyed = true;
    }
}
