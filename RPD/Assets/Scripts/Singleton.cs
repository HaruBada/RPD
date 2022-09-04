using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject inst = new GameObject();
                inst.name = typeof(T).Name;
                _instance = inst.AddComponent<T>();

                if(_instance is Singleton<T> singleton)
                {
                    singleton.Init();
                }
            }
            return _instance;
        }
    }
    virtual protected void Awake() {
        _instance = this as T;
    }

    virtual public void Init(){

    }
}