using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Unit : MonoBehaviour
{
    UnitManager _unitManager;

    UnitPaths _unitPaths;

    int currentPathIndex = 0;

    [SerializeField]
    float UnitSpeed;

    ObjectPool<Unit> _managedPool;

    public void SetManagedPool(ObjectPool<Unit> _pool)
    {
        _managedPool = _pool;
    }

    public void DestroyUnit()
    {
        _managedPool.Release(this);
    }

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

        // ���� ����
        // ��ǥ�� 
        var dirVec = currentPath - currentPos;
        transform.position += dirVec.normalized * Time.deltaTime * UnitSpeed;

        // �����ߴ��� üũ �� ������ �������� �ٲ�
        if (dirVec.magnitude < 0.05f)
        {
            currentPathIndex++;
        }
    }

    public void DieUnit()
    {
        _unitManager.Remove_Unit(this);
        Destroy(gameObject);
        //DestroyUnit();

    }


}
