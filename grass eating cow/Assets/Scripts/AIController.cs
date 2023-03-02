using UnityEngine;
using Pathfinding;

public class AIController : MonoBehaviour
{
    public float chaseSpeed = 300f;
    public float idleTime = 2f;
    public float maxDistance = 10f; // maximum distance at which the AI can detect the target

    private Seeker seeker;
    private AIDestinationSetter destinationSetter;
    private AIPath aiPath;
    private Transform target;
    private float idleTimer = 0f;

    private enum State { Idle, Find, Chase }
    private State state = State.Idle;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        destinationSetter.enabled = false;
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        switch (state)
        {
            case State.Idle:
                destinationSetter.enabled = false;
                aiPath.enabled = false;
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleTime)
                {
                    idleTimer = 0f;
                    state = State.Find;
                }
                break;

            case State.Find:
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (distanceToTarget <= maxDistance)
                {
                    destinationSetter.target = target;
                    seeker.StartPath(transform.position, target.position, OnPathComplete);
                    state = State.Chase;
                }
                break;

            case State.Chase:
                float distanceToTarget2 = Vector3.Distance(transform.position, target.position);

                destinationSetter.enabled = true;
                aiPath.enabled = true;

                if (distanceToTarget2 > maxDistance)
                {
                    aiPath.maxSpeed = 0f;
                    state = State.Idle;
                }
                

                if (aiPath.remainingDistance > aiPath.endReachedDistance)
                {
                    aiPath.maxSpeed = chaseSpeed;
                }
                else
                {
                    aiPath.maxSpeed = 0f;
                    state = State.Idle;
                }
                break;
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            aiPath.SetPath(p);
        }
    }
}
