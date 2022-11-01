using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UnitManager : Singleton<UnitManager>
{
    List<Unit> unitList = new List<Unit>();
    public List<Unit> GetUnitList => unitList;

    [SerializeField]
    GameObject unitPrefab;

    public ObjectPool<Unit> _unitPool;

    [SerializeField]
    GameObject startUnitPosition;

    [SerializeField]
    UnitPaths unitPaths;

    public UnitPaths GetUnitPaths => unitPaths;

    private void Awake()
    {
        _unitPool = new ObjectPool<Unit>(CreateUnit,OnGetUnit,OnReleaseUnit,OnDestroyUnit,maxSize:40);
    }

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
            Unit unit = Instantiate(unitPrefab, pos, startUnitPosition.transform.rotation).GetComponent<Unit>();
            //Unit unit = _unitPool.Get();
            unit.transform.SetParent(this.transform);
            unit.Init(unitPaths);

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

    Unit CreateUnit()
    {
        Unit unit = Instantiate(unitPrefab, startUnitPosition.transform).GetComponent<Unit>();
        unit.transform.SetParent(this.transform);
        unit.SetManagedPool(_unitPool);
        return unit;
    }

    void OnGetUnit(Unit unit)
    {
        unit.gameObject.SetActive(true);
    }

    void OnReleaseUnit(Unit unit)
    {
        unit.gameObject.SetActive(false);
    }

    private void OnDestroyUnit(Unit unit)
    {
        Destroy(unit.gameObject);
    }
}
