using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Zombie;

public class Civilian : NPCBase
{
    public enum CivilianState
    {
        Iddle,
        Escaping   

    }
    public CivilianState currentState;
    public NavMeshAgent agent;
    public Animator animator;

    private GameObject shipReference;

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
        currentState = CivilianState.Iddle;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override void Behavior()
    {
        Debug.Log(currentState);
        switch (currentState)
        {
            case CivilianState.Iddle:
                UpdateIddle();
                break;
            case CivilianState.Escaping:
                UpdateEscaping();
                break;
        }
    }

    void UpdateIddle()
    {
        animator.SetBool("Escaping", false);
        agent.isStopped = true;
    }

    void UpdateEscaping()
    {
        agent.isStopped = false;

        animator.SetBool("Escaping", true);
        shipReference = GameManager.instance.ReturnShip();
        Vector3 shipPositionon = shipReference.transform.position;

        agent.SetDestination(shipPositionon);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentState = CivilianState.Escaping;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentState = CivilianState.Iddle;

        }
    }
}
