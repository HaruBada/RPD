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
            _currentFigure = value;
        }
    }

        
    [SerializeField]
    GameObject unitPrefab;
    [SerializeField]
    GameObject startUnitPosition;

    [SerializeField]
    UnitPaths unitPaths;

    public UnitPaths GetUnitPaths => unitPaths;

    // interval = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("RepeatUnitSpawn", 0.1f, interval); // �ڷ�ƾ���� ������ ��.

        // Coroutine c = StartCoroutine(StartUnitSpawn());
        // StopCoroutine(c);

        StartCoroutine("StartUnitSpawn");
        // StopCoroutine("StartUnitSpawn");

        // 
        // Vector3.forward * GameTime._deltaTime;

    }

    IEnumerator StartUnitSpawn()
    {
        while(true)
        {
            Vector3 pos = startUnitPosition.transform.position;
            GameObject go = Instantiate(unitPrefab, pos, startUnitPosition.transform.rotation);
            Unit ut = go.GetComponent<Unit>();
            ut.Init(unitPaths);

            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (!_currentFigure && Input.GetMouseButtonDown(0))
        // {
        //     Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     Ray2D ray = new Ray2D(pos, Vector2.zero);
        //     RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //     if (hit.collider != null)
        //     {
        //         //Debug.Log(hit.collider.name);
        //         _currentFigure = hit.collider.GetComponent<Figure>();
        //     }
        // }

        // if (Input.GetMouseButtonUp(0))
        // {
        //     _currentFigure = null;
        // }

        if(_currentFigure)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            _currentFigure.transform.position = pos;
        }

        // 3D Raycast
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Vector3 pos = Input.mousePosition;
        //    Ray ray = Camera.main.ScreenPointToRay(pos);
        //    RaycastHit hit;

        //    // ref out
        //    // ref - �ٲ� ���� �ְ� �ƴϱ⵵ �ϰ� ����
        //    // out - null �̵� ���̵� ��ȭ����, �����������
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log(hit.collider.name);
        //    }
        //}
    }

    // unity �޼��� ����

    //void RepeatUnitSpawn()
    //{
    //    Vector3 pos = startUnitPosition.transform.position;
    //    pos.z = 0;
    //    GameObject go = Instantiate(unitPrefab, pos, startUnitPosition.transform.rotation);
    //    Unit ut = go.GetComponent<Unit>();
    //    ut.Init(unitPaths);
    //}
}
