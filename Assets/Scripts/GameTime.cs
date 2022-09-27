using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    static float _timeScale = 1f;
    public static float timeScale{
        get{
            return _timeScale;
        }
        set{
            _timeScale = value;
        }
    }

    public static float _detaTime
    {
        get{
            // Time.deltaTime -> deltaTime * timeScale;
            return Time.deltaTime * timeScale;
        }
    }
}
