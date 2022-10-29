using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureGenerateButton : MonoBehaviour
{
    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    public void OnBotton()
    {
        _gameManager.OnClickedSummon();

    }
}
