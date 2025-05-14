using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBullet : BaseBullet
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float lifeTime;
    private float timeLeft = 0;

    private void FixedUpdate()
    {
        if (!isActivated) return;
        Fire();
        Timer();
    }

    protected override void Fire()
    {
        rb.velocity = transform.up * speed;
    }

    public virtual void Timer()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft > lifeTime) 
        {
            isActivated = false;
            ReturnObjectToPool();
        }

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
