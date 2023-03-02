using UnityEngine;
using Pathfinding;

public class AiCrow : MonoBehaviour
{
    public float chaseSpeed = 300f;
    public float patrolTime = 7.5f;
    public float maxDistance = 10f; // Not Needed right now, but will implement later

    private Seeker seeker;
    private AIDestinationSetter destinationSetter;
    private AIPath aiPath;
    private Transform target;
    private float patrolTimer = 0f;
    private Patrol patrol;

    private enum State { Patrol, Find, Eat }
    private State state = State.Patrol;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        patrol = GetComponent<Patrol>();
        destinationSetter.enabled = false;
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Food").transform;
        switch (state)
        {
            case State.Patrol:
                destinationSetter.enabled = false;
                aiPath.enabled = true;
                aiPath.maxSpeed = chaseSpeed;
                patrol.enabled = true;
                patrolTimer += Time.deltaTime;
                if (patrolTimer >= patrolTime)
                {
                    patrolTimer = 0f;
                    state = State.Find;
                }
                break;

            case State.Find:
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (distanceToTarget <= maxDistance)
                {
                    destinationSetter.target = target;
                    seeker.StartPath(transform.position, target.position, OnPathComplete);
                    patrol.enabled = false;
         
                    state = State.Eat;
                }
                else
                {
                    state = State.Patrol;
                }
                break;

            case State.Eat:

                if (aiPath.remainingDistance > aiPath.endReachedDistance)
                {
                    destinationSetter.enabled = true;
                    if(!target)
                        destinationSetter.enabled = false;
                        state = State.Patrol;
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
