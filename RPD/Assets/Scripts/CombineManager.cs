using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineManager : Singleton<CombineManager>
{
    public List<IFigure> figures = new List<IFigure>();

    bool isCombining;
    public bool IsCombining
    {
        get
        {
            return isCombining;
        }
        set
        {
            isCombining = value;
        }
    }
    public void Add_FIgure(IFigure figure)
    {
        figures.Add(figure);
    }

    public void Combine(List<GameObject> collissionObject, GameObject mainobject)
    {
        //Ÿ�� �񱳴� IFigure, ������Ʈ �ı��� Figure �Ǵ� GameObject
        // figures list �� �ҷ��� �浹������Ʈ �� ��ü������Ʈ�� Ÿ�� �񱳸� ��� ����..
        for(int i = 0; i < 2; i++)
        {
            Destroy(collissionObject[0]);
        }
        Destroy(mainobject);
        // �� �������� ��ȯ�ϴ� ���� ������ �ٸ�.
        Debug.Log("Combine Complete");
        IsCombining = false;
    }

    private void Start()
    {
        isCombining = false;
    }
}
