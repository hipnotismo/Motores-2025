using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIddleState : MonoBehaviour, IEnemyState
{
    bool seeTarget = false;

    public IEnemyState Behavior(EnemyStateManager enemy)
    {

        if (enemy.animator == null)
        {
            enemy.animator = enemy.GetComponent<Animator>();

        }

        if (seeTarget == true)
        {
            enemy.SwitchState(enemy.chaseState);
            seeTarget = false;
            Debug.Log("Switch to chase");

        }
        enemy.animator.SetBool("Walking", false);
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Enters");
            seeTarget = true;
        }
    }
}
