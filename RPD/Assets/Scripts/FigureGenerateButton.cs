using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerateButton : MonoBehaviour
{
    [SerializeField]
    GameObject FigurePrefab;

    public void OnBotton()
    {
        //Debug.Log("Figure Button Start");
        Instantiate(FigurePrefab);
        //Debug.Log("Figure Button End");
    }
}
