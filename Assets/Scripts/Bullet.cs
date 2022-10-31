using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    Unit _targetUnit;

    [SerializeField]
    float bulletSpeed;

    IObjectPool<Bullet> _managedPool;

    public void SetManagedPool(IObjectPool<Bullet> _pool)
    {
        _managedPool = _pool;
    }

    public void DestroyBullet()
    {
        _managedPool.Release(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTarget(Unit targetUnit)
    {
        _targetUnit = targetUnit;
    }

    // Update is called once per frame
    void Update()
    {
        if(_targetUnit != null)
        {
            Vector3 dir = _targetUnit.transform.position - transform.position;

            transform.position += dir.normalized * Time.deltaTime * bulletSpeed;
        }
        else
        {
            Debug.Log("no target");
            //Destroy(gameObject);
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Unit")) return;
        if (collision.GetComponent<Unit>() != _targetUnit) return;

        Debug.Log("trigger");

        collision.GetComponent<Unit>().DieUnit();
        //Destroy(gameObject);
        DestroyBullet();
    }
}
