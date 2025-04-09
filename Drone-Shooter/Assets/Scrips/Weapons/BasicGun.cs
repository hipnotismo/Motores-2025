using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BasicGun : MonoBehaviour
{
    public Transform BulletSpawnPoint;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    public void Shoot()
    {
        RaycastHit hit;

        Vector3 spawnPosition = BulletSpawnPoint.transform.position;
        Vector3 spawnDirection = BulletSpawnPoint.transform.forward;

        Physics.Raycast(spawnPosition, spawnDirection, out hit, 100f);
            Debug.Log(hit.transform.name);

            ITakeDamage isHit = hit.collider.GetComponent<ITakeDamage>();


            if (isHit != null)
            {
                isHit.TakeDamage();
            }
       
    }

}
