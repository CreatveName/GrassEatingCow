using System.Collections;
using UnityEngine;
using Pathfinding;

public class AIWolf : MonoBehaviour
{
     [SerializeField]
    private Seeker seeker;
    [SerializeField]
    private AIDestinationSetter destinationSetter;
    [SerializeField]
    private AIPath aiPath;
    [SerializeField]
    private Animator anim;


    [SerializeField]
    private float chaseSpeed = 300f;
    [SerializeField]
    private float idleTime = 2f;
    [SerializeField]
    private float maxDistance = 10f; // maximum distance at which the AI can detect the target
    [SerializeField]
    private Transform target;
    private float idleTimer = 0f;

    private enum State { Idle, Find, Wander, Chase }
    [SerializeField]
    private State state = State.Idle;

    void Start()
    {
        destinationSetter.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform;
        }
        else
        {
            target = null;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform;
        }
        else
        {
            target = null;
        }
    }
    

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                anim.SetBool("isFinding", false);
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
                //float findTimer = 2f;

                anim.SetBool("isFinding", true);
                if(target)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    if (distanceToTarget <= maxDistance)
                    {
                        destinationSetter.target = target;
                        seeker.StartPath(transform.position, target.position, OnPathComplete);
                        state = State.Chase;
                    }
                }
           
                break;

            case State.Chase:
                anim.SetBool("isFinding", false);
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
