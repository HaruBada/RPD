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

    [SerializeField]
    GameObject figurePrefab;
    public List<int> summonFigureIdx = new List<int> { 1, 2, 3 };

    [SerializeField] int sortingDepth = 2000;
    // managers
    FigureDataManager _figureDataManager;

    private void Awake()
    {
        _figureDataManager = FigureDataManager.Instance;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedSummon()
    {
        int figureRandom = Random.Range(0, summonFigureIdx.Count);
        SummonFigure(summonFigureIdx[figureRandom], Vector3.zero);
    }

    public Figure SummonFigure(int idx, Vector3 pos)
    {
        FigureData data = _figureDataManager.Get(idx);
        GameObject go = Instantiate(figurePrefab);
        go.transform.position = pos;

        Figure f = go.GetComponent<Figure>();
        f.Init(data);

        return f;
    }

    public int GetFigureSortingOrder(float ypos)
    {
        return (int)(sortingDepth - ypos * 100);
    }
}
