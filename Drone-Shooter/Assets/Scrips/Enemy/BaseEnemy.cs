using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, ITakeDamage
{
    public int life;
    public int currentLife;

    private void Start()
    {
        currentLife = life;
    }
    public void TakeDamage()
    {
        if (currentLife > 0)
        {
            currentLife--;

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
