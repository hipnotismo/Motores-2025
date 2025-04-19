using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int timer;
    public List<GameObject> spawnPoints;
    public List<string> tags;
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= timer)
        {
            Spawn();
            //Instantiate(enemies[a], transform.position, transform.rotation);
            counter = 0f;

        }
    }

   private void Spawn()
    {
        Debug.Log("start spwn");
        int randomTag = UnityEngine.Random.Range(0, tags.Count);
        int randomPos = UnityEngine.Random.Range(0, spawnPoints.Count);
        PoolManager.instance.SpawnFromPool(tags[randomTag], spawnPoints[randomPos].transform.position, Quaternion.identity);
    }
}
