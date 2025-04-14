using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooling : MonoBehaviour
{
    public static ProjectilePooling instace;

    private List<GameObject> pooledProjectiles = new List<GameObject>();
    private int amountToPool = 20;

    [SerializeField] private GameObject projectilePrefab;

    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < amountToPool; i++) 
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            pooledProjectiles.Add(obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        for(int i = 0; i < pooledProjectiles.Count; i++)
        {
            if (!pooledProjectiles[i].activeInHierarchy)
            {
                return pooledProjectiles[i];
            }
        }

        return null;
    }
}
