using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWanderingState : MonoBehaviour, IEnemyState
{
    public IEnemyState Behavior(EnemyStateManager enemy)
    {
        Debug.LogError("Wandering state");

        Vector3 point;
        if (RandomPoint(transform.position, enemy.range, out point))
        {
            enemy.agent.SetDestination(point);
        }

        enemy.animator.SetBool("Walking", true);

        enemy.agent.SetDestination(enemy.playerPosition);

        return this;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {

            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
