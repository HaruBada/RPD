using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    Figure _currentFigure;
    public Figure CurrentFigure 
    { 
        get
        {
            return _currentFigure;
        }
        set
        {
            _selectFigure = value;
            _currentFigure = value;
        }
    }
    Figure _selectFigure;

    // Update is called once per frame
    void Update()
    {
        
    }

}
