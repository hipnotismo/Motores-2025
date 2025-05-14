using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBullet : BaseBullet
{
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        if (!isActivated) return;
        Fire();
    }

    protected override void Fire()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        ITakeDamage isHit = other.gameObject.GetComponent<ITakeDamage>();
        if (isHit != null)
        {
            isHit.TakeDamage();
        }
        isActivated = false;
        ReturnObjectToPool();
    }

    public override void CalculateTrajectory(Vector3 position, Vector3 direction, Quaternion spawnRotation)
    {
        isActivated = true;
        transform.position = position;
        transform.rotation = spawnRotation;
        transform.up = direction;

    }
}
