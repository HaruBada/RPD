using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PropertyManager : Singleton<PropertyManager>
{
    int _mineral;
    public int Mineral
    {
        get
        {
            return _mineral;
        }
        set
        {
            _mineral = value;
        }
    }

    int _gold;
    public int Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _mineral = 0;
    }

}
