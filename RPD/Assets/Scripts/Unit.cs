using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    UnitPaths _unitPaths;

    int currentPathIndex = 0;

    [SerializeField]
    float UnitSpeed;

    public void Init(UnitPaths unitPaths)
    {
        _unitPaths = unitPaths;
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
}
