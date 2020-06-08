using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance;

    public GameObject BulletPrefab;
    public int BulletCountInPool;

    private List<Bullet> bulletsPool = new List<Bullet>();

    public static ObjectPool Instance { get => instance; }

    private void Awake()
    {
        instance = this;
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < BulletCountInPool; i++)
        {
            CreateBullet();
        }
    }

    public Bullet GetBulletFromThePool()
    {
        if(bulletsPool.Count == 0)
        {
            CreateBullet();
        }
        Bullet bullet = bulletsPool[0];
        bulletsPool.RemoveAt(0);
        return bullet;
    }

    public void CreateBullet()
    {
        Bullet newBullet = Instantiate(BulletPrefab).GetComponent<Bullet>();
        newBullet.gameObject.SetActive(false);
        bulletsPool.Add(newBullet);
    }

    public void ReturnBulletIntoPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletsPool.Add(bullet);
    }
}
