using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerateButton : MonoBehaviour
{
    [SerializeField]
    GameObject squarePrefab;
    [SerializeField]
    GameObject circlePrefab;
    [SerializeField]
    GameObject trianglePrefab;


    public void OnBotton()
    {
        int figureRandom = Random.Range(0,100) % 3 + 1;

        switch (figureRandom)
        {
            case 1:
                Instantiate(squarePrefab);
                break;
            case 2:
                Instantiate(circlePrefab);
                break;
            case 3:
                Instantiate(trianglePrefab);
                break;
        }

    }
}
