using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, ITakeDamage
{
    [SerializeField] int life;
    private int currentLife;

    private bool immune = false;

    void Start()
    {
        currentLife = life;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy" && immune == false)
        {
            TakeDamage();
            StartCoroutine(immunity());
        }
    }
    public void TakeDamage()
    {
        if (currentLife > 0) {
            currentLife--;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    IEnumerator immunity()
    {
        immune = true;
        yield return new WaitForSeconds(3);
        immune = false;
        Debug.Log("time up");
    }
}
