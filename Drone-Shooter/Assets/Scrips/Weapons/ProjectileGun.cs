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

        PhysicBullet bullet = PoolManager.Instance.Get<PhysicBullet>();
        bullet.gameObject.SetActive(true);
        bullet.CalculateTrajectory(bulletSpawnPoint.position, transform.forward, transform.rotation);
    }
}
