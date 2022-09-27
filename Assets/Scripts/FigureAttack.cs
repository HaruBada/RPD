using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackState { SearchTarget, AttackTarget }

public class FigureAttack : MonoBehaviour
{
    UnitManager _unitManager;
    Unit TargetUnit;

    AttackState attackState = AttackState.SearchTarget;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float attackCoolTime;

    // Start is called before the first frame update
    void Start()
    {
        if (!_unitManager)
        {
            _unitManager = UnitManager.Instance;
        }

        StartCoroutine("SearchTarget");
    }

    private IEnumerator SearchTarget()
    {
        while(true)
        {
            float closestDistance = Mathf.Infinity;
            for(int i = 0; i < _unitManager.GetUnitList.Count; i++)
            {
                float distance = Vector3.Distance(_unitManager.GetUnitList[i].transform.position, this.transform.position);
                if (distance <= attackRange && distance < closestDistance)
                {
                    closestDistance = distance;
                    TargetUnit = _unitManager.GetUnitList[i];
                }
            }

            if(TargetUnit != null)
            {
                ChangeState(AttackState.AttackTarget);
            }

            yield return null;
        }
    }

    private IEnumerator AttackTarget()
    {
        while(true)
        {
            if(!TargetUnit)
            {
                ChangeState(AttackState.SearchTarget);
                break;
            }

            float distance = Vector3.Distance(TargetUnit.transform.position, this.transform.position);
            if(distance > attackRange)
            {
                TargetUnit = null;
                ChangeState(AttackState.SearchTarget);
                break;
            }

            yield return new WaitForSeconds(attackCoolTime);

            Debug.Log("Shot");
        }
    }

    void ChangeState(AttackState newSate)
    {
        StopCoroutine(attackState.ToString());
        attackState = newSate;
        StartCoroutine(attackState.ToString());
    }
}