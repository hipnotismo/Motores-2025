using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObjectSpawner : MonoBehaviour
{
    [SerializeField] private PhysicBullet physicBulletPrefab;

    void Start()
    {
        PoolManager.Instance.InitializePool(physicBulletPrefab, 15);

    }
}
