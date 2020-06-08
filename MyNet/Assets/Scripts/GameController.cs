using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance; //Singleton pattern

    //Action delegate event structure
    public delegate void SimpleCallBack();
    public event SimpleCallBack OnFire; //Event works to coordinate all cannons fire simultaneously.
    
    //In Game Values before special power
    [SerializeField] private int fireRate;
    [SerializeField] private float firePeriod;
    [SerializeField] private float bulletSpeed;

    //In GameObjects
    [SerializeField] private GameObject[] crossCannons;
    [SerializeField] private GameObject extraCannon;
    [SerializeField] private GameObject mainCannon;

    //Encapsulated Fields
    public float FireRate { get => fireRate; }
    public float FirePeriod { get => firePeriod; }
    public float BulletSpeed { get => bulletSpeed; }
    public static GameController Instance { get => instance;}
    

    //Special Power Values. These values are the values after player uses a special power
    [SerializeField] private int specialFireRate;
    [SerializeField] private float specialFirePeriod;
    [SerializeField] private float specialBulletSpeed;

    //All starts when GameObject is active
    private void Awake()
    {
        instance = this;
        StartFiring();
    }

    #region Special Power Functions
    public void UseFireRatePower()
    {
        this.fireRate = specialFireRate;
    }

    //
    public void UseFirePeriodPower()
    {
        this.firePeriod = specialFirePeriod;
    }

    //Changes Bullet Speed
    public void UseBulletSpeedPower()
    {
        this.bulletSpeed = specialBulletSpeed;
    }

    //Activates extra cannons that targets 45 degree right/left sides
    //Cross cannons are the children of the main cannons. So there is no need to check if extra main cannon power active
    public void UseCrossCannonPower()
    {
        for (int i = 0; i < crossCannons.Length; i++)
        {
            crossCannons[i].SetActive(true);
        }
    }

    public void UseExtraCannonPower()
    {
        mainCannon.transform.position = new Vector3(-3, mainCannon.transform.position.y, mainCannon.transform.position.z);
        extraCannon.SetActive(true);
    }

    #endregion

    #region Firing Functions
    //Starts firing process for the game, continues until finish the scene
    public void StartFiring()
    {
        StartCoroutine(FireRoutine());
    }

    //Repeating routine only affected by value changes
    public IEnumerator FireRoutine()
    {
        for (int i = 0; i < fireRate; i++)
        {
            OnFire?.Invoke(); //Event has been subscribed in Cannon.cs as a cannon is active
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(firePeriod - .1f);
        StartCoroutine(FireRoutine());
    }
    #endregion
}
