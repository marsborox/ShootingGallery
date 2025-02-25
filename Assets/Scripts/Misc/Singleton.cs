using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    private static T instance;

    public static T Instance { get { return instance; } }
    //it will be like semi private, acessible only to whoever directly inherits
    protected virtual void Awake()
    {
        if (instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);
        }
        else
        {//instance needs to be casted as generic type
            instance = (T)this;
        }
        DontDestroyOnLoad(gameObject);
    }
}

