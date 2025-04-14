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
        GameObject bullet = ProjectilePooling.instace.GetPooledObjects();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.SetActive(true);
        }

    }
}
