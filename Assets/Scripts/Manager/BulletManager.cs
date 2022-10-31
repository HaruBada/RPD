using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : Singleton<BulletManager>
{

    [SerializeField]
    GameObject prefabBullet;

    public IObjectPool<Bullet> _pool;
    

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize: 20);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(prefabBullet).GetComponent<Bullet>();
        bullet.transform.SetParent(this.transform);
        bullet.SetManagedPool(_pool);
        return bullet;
    }

    void OnGetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

}
