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
                    Debug.Assert(inst != null, "싱글턴 생성 실패");
                }
            }

            return _instance;
        }
    }

    virtual public void Init(){

    }

    public virtual void OnDestroy()
    {
        // 오브젝트가 삭제가 될때
        _instance = null;
    }

    private void OnApplicationQuit()
    {
        // 앱이 종료가 될때
        bShutdown = true;
        _instance = null;
    }
}