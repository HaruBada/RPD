using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static bool bShutdown = false;
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                if (bShutdown == false)
                {
                    T inst = GameObject.FindObjectOfType<T>() as T;
                    if (inst == null)
                    {
                        inst = new GameObject(typeof(T).ToString()
                            , typeof(T)).GetComponent<T>();
                    }

                    _instance = inst;
                    if (_instance is Singleton<T> singleton)
                    {
                        singleton.Init();
                    }
                    Debug.Assert(inst != null, "�̱��� ���� ����");
                }
            }

            return _instance;
        }
    }

    virtual public void Init(){

    }

    public virtual void OnDestroy()
    {
        // ������Ʈ�� ������ �ɶ�
        _instance = null;
    }

    private void OnApplicationQuit()
    {
        // ���� ���ᰡ �ɶ�
        bShutdown = true;
        _instance = null;
    }
}