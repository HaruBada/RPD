using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    UnitManager _unitManager;

    UnitPaths _unitPaths;

    int currentPathIndex = 0;

    [SerializeField]
    float UnitSpeed;

    public void Init(UnitPaths unitPaths)
    {
        _unitPaths = unitPaths;
    }

    private void Start()
    {
        if(!_unitManager)
        {
            _unitManager = UnitManager.Instance;
        }
        _unitManager.Add_Unit(this);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentPathIndex >= _unitPaths.GetPaths.Count)
        {
            currentPathIndex = 0;
            return;
        }

        var currentPath = _unitPaths.GetPaths[currentPathIndex].transform.position;
        var currentPos = transform.position;

        // 방향 백터
        // 좌표계 
        var dirVec = currentPath - currentPos;
        transform.position += dirVec.normalized * Time.deltaTime * UnitSpeed;

        // 도착했는지 체크 후 목적지 다음으로 바꿈
        if (dirVec.magnitude < 0.05f)
        {
            currentPathIndex++;
        }
    }

    public void DieUnit()
    {
        _unitManager.Remove_Unit(this);
        Destroy(gameObject);

    }
}
