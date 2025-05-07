using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private IEnemyState currentState;

    public Animator animator;
    public NavMeshAgent agent;

    public EnemyIddleState iddleState = new EnemyIddleState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyWanderingState wanderingState = new EnemyWanderingState();

    public float range; //radius of sphere

    public Transform centrePoint;
    public GameObject playerReference;
    public Vector3 playerPosition;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();


        currentState = iddleState;
    }

    private void Start()
    {
        playerReference = GameManager.instance.ReturnPlayer();

    }
    private void Update()
    {
        currentState = currentState.Behavior(this);
        Debug.LogError(currentState);

    }

    public void SwitchState(IEnemyState state)
    {
        currentState = state;
        Debug.Log("Changed State " + state + " : " + currentState);

        state.Behavior(this);
    }
}
