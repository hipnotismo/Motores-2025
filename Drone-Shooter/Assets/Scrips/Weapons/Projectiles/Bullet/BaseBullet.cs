using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour, IPooleable
{
    public Vector3 direction;
    public bool isActivated;

    public float speed;

    protected virtual void Fire() { }
    public virtual void CalculateTrajectory(Vector3 initialPosition, Vector3 direction, Quaternion rotation) { }
    public virtual void CalculateTrajectory(Vector3 initialPosition, Vector3 finalPosition) { }

    public void ReturnObjectToPool()
    {
        PoolManager.Instance.ReturnToPool(this);
    }
}
