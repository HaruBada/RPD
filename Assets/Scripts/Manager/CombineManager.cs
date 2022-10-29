using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineManager : Singleton<CombineManager>
{
    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    public void Combine(List<Figure> collissionObject, Figure mainobject)
    {
        int count = collissionObject.Count;
        for (int i = 0; i < count; i++)
        {
            collissionObject[0].isCombine = true;
            Destroy(collissionObject[0].gameObject);
        }
        mainobject.isCombine = true;

        FigureData data = mainobject.GetFigureData;
        int eidx = Random.Range(0, data.evolutions.Count);
        int nextIdx = data.evolutions[eidx];
        Figure figure = _gameManager.SummonFigure(nextIdx, mainobject.transform.position);
        _gameManager.CurrentFigure = figure;
        figure.CheckMaxLevel();

        Destroy(mainobject.gameObject);

        ////Ÿ�� �񱳴� IFigure, ������Ʈ �ı��� Figure �Ǵ� GameObject
        //// figures list �� �ҷ��� �浹������Ʈ �� ��ü������Ʈ�� Ÿ�� �񱳸� ��� ����..
        //for(int i = 0; i < 2; i++)
        //{
        //    Destroy(collissionObject[0]);
        //}
        //Destroy(mainobject);
        //// �� �������� ��ȯ�ϴ� ���� ������ �ٸ�.
        //Debug.Log("Combine Complete");
        //IsCombining = false;
    }

    private void Start()
    {
        
    }
}
