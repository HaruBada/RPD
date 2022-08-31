using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Figure _currentFigure;

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
        //InvokeRepeating("RepeatUnitSpawn", 0.1f, interval); // 코루틴으로 변경할 것.

        StartCoroutine(StartUnitSpawn());
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
        if (!_currentFigure && Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.name);
                _currentFigure = hit.collider.GetComponent<Figure>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentFigure = null;
        }

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
        //    // ref - 바뀔 수도 있고 아니기도 하고 참조
        //    // out - null 이든 값이든 변화있음, 세팅해줘야함
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Debug.Log(hit.collider.name);
        //    }
        //}
    }

    // unity 메세지 구현

    //void RepeatUnitSpawn()
    //{
    //    Vector3 pos = startUnitPosition.transform.position;
    //    pos.z = 0;
    //    GameObject go = Instantiate(unitPrefab, pos, startUnitPosition.transform.rotation);
    //    Unit ut = go.GetComponent<Unit>();
    //    ut.Init(unitPaths);
    //}
}
