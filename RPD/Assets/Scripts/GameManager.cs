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
    GameObject unitPrefab;
    [SerializeField]
    GameObject startUnitPosition;

    [SerializeField]
    UnitPaths unitPaths;

    public UnitPaths GetUnitPaths => unitPaths;

    // Start is called before the first frame update
    void Start()
    {
        // Coroutine c = StartCoroutine(StartUnitSpawn());
        // StopCoroutine(c);

        StartCoroutine("StartUnitSpawn");
        
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
        
    }

}
