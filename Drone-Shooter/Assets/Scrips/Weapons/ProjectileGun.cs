using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Shoot()
    {      

        PoolManager.instance.SpawnFromPool("Bullets",transform.position,Quaternion.identity);
    }
}
