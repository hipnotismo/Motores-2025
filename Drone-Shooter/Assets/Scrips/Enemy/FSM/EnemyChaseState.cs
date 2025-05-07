using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : MonoBehaviour, IEnemyState
{
    bool targetEscape = false;

    public IEnemyState Behavior(EnemyStateManager enemy)
    {
        Debug.LogError("Chase state");

        enemy.playerPosition = enemy.playerReference.transform.position;

        enemy.animator.SetBool("Walking", true);

        enemy.agent.SetDestination(enemy.playerPosition);

        if (targetEscape == true)
        {
            enemy.SwitchState(enemy.wanderingState);
            targetEscape = false;
            Debug.Log("Switch to wandering");

        }
        return this;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetEscape = true;
            Debug.Log("Player out");
        }
    }
}
