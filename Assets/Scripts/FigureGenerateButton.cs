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

    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    public void OnBotton()
    {
        _gameManager.OnClickedSummon();


        //switch (figureRandom)
        //{
        //    case 1:
        //        Instantiate(squarePrefab);
        //        break;
        //    case 2:
        //        Instantiate(circlePrefab);
        //        break;
        //    case 3:
        //        Instantiate(trianglePrefab);
        //        break;
        //}

    }
}
