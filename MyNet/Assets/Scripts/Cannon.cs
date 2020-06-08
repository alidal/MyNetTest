using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform bulletFirePoint; //Bullet spawn point

    private void Start()
    {
        GameController.Instance.OnFire += Fire; //Registers an event as the game object is active
    }

    //Fire projector on a Cannon sends one bullet taken from object pool
    public void Fire()
    {
        Bullet bulletToFire = ObjectPool.Instance.GetBulletFromThePool();
        bulletToFire.transform.position = bulletFirePoint.position;
        bulletToFire.FireBullet(-transform.forward * GameController.Instance.BulletSpeed);
    }
}
