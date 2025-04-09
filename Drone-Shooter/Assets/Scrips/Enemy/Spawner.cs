using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int timer;
    public List<GameObject> enemies;
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= timer)
        {
            Debug.Log("start spwn");
            int a = UnityEngine.Random.Range(0, enemies.Count);
            Instantiate(enemies[a], transform.position, transform.rotation);
            counter = 0f;

        }
    }

   
}
