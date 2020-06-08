using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rigid;
    public float PoolBackTime;

    //Starts bullet fire process until its lifetime ends to back object pool to start again.
    public void FireBullet(Vector3 speed)
    {
        SetSpeed(speed);
        gameObject.SetActive(true);
        StartCoroutine(PoolBackAfterWhile());
    }

    //Starts bullet move to the direction of speed
    public void SetSpeed(Vector3 speed)
    {
        rigid.velocity = speed; 
    }

    //Destroys bullet and game object returns to the pool to be reused
    public IEnumerator PoolBackAfterWhile()
    {
        yield return new WaitForSeconds(PoolBackTime);
        ObjectPool.Instance.ReturnBulletIntoPool(this);
    }
}
