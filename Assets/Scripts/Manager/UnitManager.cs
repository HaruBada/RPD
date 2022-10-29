using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    List<Unit> unitList = new List<Unit>();
    public List<Unit> GetUnitList => unitList;

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
        while (true)
        {
            Vector3 pos = startUnitPosition.transform.position;
            GameObject go = Instantiate(unitPrefab, pos, startUnitPosition.transform.rotation);
            go.transform.SetParent(this.transform);
            Unit ut = go.GetComponent<Unit>();
            ut.Init(unitPaths);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Add_Unit(Unit unit)
    {
        unitList.Add(unit);
    }
    public void Remove_Unit(Unit unit)
    {
        unitList.Remove(unit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
