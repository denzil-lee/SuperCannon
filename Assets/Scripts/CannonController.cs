using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonController : Singleton<CannonController>
{
     
    [SerializeField] GameObject bullet1Prefab;
    [SerializeField] GameObject bullet2Prefab;
    [SerializeField] Transform cannonTip;
    [SerializeField] float fire1Rate, fire2Rate;

    public ObjectPooling cannonBallPool, missilePool;

    Quaternion clampRotationLow, clampRotationHigh;

    Coroutine fire1coroutine, fire2coroutine;
    GameObject pooledCannonBall, pooledMissile;

    // Start is called before the first frame update
    void Start()
    {
        clampRotationLow = Quaternion.Euler(0, 0, -70f);
        clampRotationHigh = Quaternion.Euler(0, 0, +70f);
    }

    // Update is called once per frame
    void Update()
    {
        PointAtMouse();

        if (Input.GetMouseButtonDown(0))
        {
            if (fire1coroutine == null)
            {
                //pooledCannonBall = cannonBallPool.GetPoolObject();
                fire1coroutine = StartCoroutine(FireContinuously(cannonBallPool, fire1Rate));
            }
                
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (fire2coroutine == null)
            {
              //  pooledMissile = missilePool.GetPoolObject();
                fire2coroutine = StartCoroutine(FireContinuously(missilePool, fire2Rate));
            }
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            if (fire1coroutine != null) StopCoroutine(fire1coroutine);
            fire1coroutine = null;
        }

        if (Input.GetMouseButtonUp(1)) 
        {
            if (fire2coroutine != null) StopCoroutine(fire2coroutine);
            fire2coroutine = null;
        }

    }

    IEnumerator FireContinuously(ObjectPooling bulletPool, float _firingRate)
    {
        while (true)
        {
            GameObject pooledBullet = bulletPool.GetPoolObject();
            pooledBullet.transform.position = cannonTip.position;
            pooledBullet.transform.rotation = cannonTip.rotation;
            pooledBullet.SetActive(true);  //Instantiate(bulletPrefab, cannonTip.position, cannonTip.rotation);
            yield return new WaitForSeconds(_firingRate);
        }
    }

    private void PointAtMouse()
    {
       
        Vector3 relativePos = this.transform.position - GameData.MousePos;
        Quaternion newrotation = Quaternion.LookRotation(relativePos, Vector3.forward);
        newrotation.x = 0;
        newrotation.y = 0;
        newrotation.z = Mathf.Clamp(newrotation.z, clampRotationLow.z, clampRotationHigh.z);
        newrotation.w = Mathf.Clamp(newrotation.w, clampRotationLow.w, clampRotationHigh.w);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, newrotation, Time.deltaTime * 3);
    }


}
