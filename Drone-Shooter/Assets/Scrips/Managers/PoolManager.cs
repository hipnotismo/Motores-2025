using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static PoolManager instance;

    private void Awake()
    {
        instance = this;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject> ();
            for (int i = 0; i < pool.size; i++) 
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive (false);
                objectPool.Enqueue (obj);
            }
            poolDictionary.Add (pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {

        try
        {
            poolDictionary.ContainsKey(tag);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive (true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        poolDictionary[tag].Enqueue (objectToSpawn);

        return objectToSpawn;
    }
}
