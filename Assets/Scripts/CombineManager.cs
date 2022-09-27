using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineManager : Singleton<CombineManager>
{
    public List<IFigure> figures = new List<IFigure>();

   
    public void Add_FIgure(IFigure figure)
    {
        figures.Add(figure);
    }

    public void Combine(List<Figure> collissionObject, Figure mainobject)
    {
        int count = collissionObject.Count;
        for (int i = 0; i < count; i++)
        {
            Destroy(collissionObject[0].gameObject);
        }

        ////타입 비교는 IFigure, 오브젝트 파괴는 Figure 또는 GameObject
        //// figures list 랑 불러온 충돌오브젝트 및 주체오브젝트는 타입 비교를 어떻게 하지..
        //for(int i = 0; i < 2; i++)
        //{
        //    Destroy(collissionObject[0]);
        //}
        //Destroy(mainobject);
        //// 각 도형마다 소환하는 상위 도형이 다름.
        //Debug.Log("Combine Complete");
        //IsCombining = false;
    }

    private void Start()
    {
        
    }
}
