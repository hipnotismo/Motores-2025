using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : NPCBase
{
    public enum EnemyState
    {
        Wandering,
        Chase
        
    }
    public EnemyState currentState;
    public NavMeshAgent agent;
    public Animator animator;

    private float range;

    private GameObject playerReference;

    void Start()
    {
        Setup();
    }

    void Update()
    {
        Behavior();
    }

    public override void Setup()
    {
        currentState = EnemyState.Wandering;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        range = 10;
    }

    public override void Behavior()
    {
        switch (currentState)
        {
            case EnemyState.Wandering:
                UpdateWandering();
                break;
            case EnemyState.Chase:
                UpdateChase();
                break;
        }
    }

    void UpdateWandering()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            agent.SetDestination(point);
        }

        animator.SetBool("Walking", true);
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

    void UpdateChase()
    {
        playerReference = GameManager.instance.ReturnPlayer();
        Vector3 playerPositionon = playerReference.transform.position;

        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            agent.SetDestination(point);
        }

        animator.SetBool("Walking", true);

        agent.SetDestination(playerPositionon);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            currentState = EnemyState.Chase;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentState = EnemyState.Wandering;

        }
    }
}
