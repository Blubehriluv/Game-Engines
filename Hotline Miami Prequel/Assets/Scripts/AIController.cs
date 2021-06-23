using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform followTarget;
    public float decisionDelay = 10.0f;
    private float nextDecisionTime;
    [SerializeField] private float enemyDistance;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    // This tells the NavMeshAgent what it will be moving towards
    public void SetDestination()
    {
        // If the amount of time it takes to make a decision has passed
        // the AI can begin making another decision.
        if (Time.time >= nextDecisionTime)
        {
            // Only current decision is to chase the player's position
            agent.SetDestination(followTarget.position);
            nextDecisionTime = Time.deltaTime + decisionDelay;
            MoveAgent();
        }

        
    }

    // Root motion notifies the NavMeshAgent
    public void OnAnimatorMove()
    {
        // When animator moves enemy, tell NavMesh
        agent.velocity = anim.velocity;
    }


    // This moves the agent according to the velocity of it's animation (root motion)
    public void MoveAgent()
    {
        Vector3 input = agent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        anim.SetFloat("Horizontal", followTarget.position.x);
        anim.SetFloat("Vertical", followTarget.position.z);

        OnAnimatorMove();
    }
}
