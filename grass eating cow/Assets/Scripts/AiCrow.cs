using UnityEngine;
using Pathfinding;

public class AiCrow : MonoBehaviour
{
    [SerializeField]
    private float eatSpeed;
    [SerializeField]
    private float patrolSpeed;
    [SerializeField]
    private float patrolTime;
    [SerializeField]
    private float maxDistance; // Not Needed right now, but will implement later
    [SerializeField]
    private Seeker seeker;
    [SerializeField]
    private AIDestinationSetter destinationSetter;
    [SerializeField]
    private AIPath aiPath;
    private Transform target;
    private float patrolTimer = 0f;
    [SerializeField]
    private Patrol patrol;

    private enum State { Patrol, Find, Eat }
    [SerializeField]
    private State state = State.Patrol;

    void Start()
    {
        destinationSetter.enabled = false;
    }

    void Update()
    {
        //summary: Crow patrols around map then searches for food, if food found speed up to eat food, then go back to patroling
        switch (state)
        {
            case State.Patrol:
                destinationSetter.enabled = false;
                aiPath.maxSpeed = patrolSpeed;
                patrol.enabled = true;
                patrolTimer += Time.deltaTime;
                if (patrolTimer >= patrolTime)
                {
                    patrolTimer = 0f;
                    state = State.Find;
                }
                break;

            case State.Find:
                target = GameObject.FindGameObjectWithTag("Food").transform;
                patrol.enabled = false;
  
                if(target)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (distanceToTarget <= maxDistance)
                    {
                        destinationSetter.target = target;
                        seeker.StartPath(transform.position, target.position, OnPathComplete);
         
                        state = State.Eat;
                    }
                }
                
                break;

            case State.Eat:
                aiPath.maxSpeed = eatSpeed;

                if (aiPath.remainingDistance > aiPath.endReachedDistance)
                {
                    destinationSetter.enabled = true;
                }
                if(aiPath.reachedDestination)
                {
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
