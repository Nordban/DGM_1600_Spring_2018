using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfNavMesh : MonoBehaviour {

    //public variables
    public Transform player;
    public float speed;
    //Wander
    public float alertDist;
    public float wanderRadius;
    //Detection
    public float wanderTimer;
    public float attackDist;

    private Animator state;
    private Vector3 direction;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private float distance;



    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

    }


    // Use this for initialization
    void Start ()
    {
        state = GetComponent<Animator>();
        distance = Vector3.Distance(player.position, transform.position);
        state.SetBool("isWandering", true);
        Debug.Log("Wandering is set to true");


	}
	
	// Update is called once per frame
	void Update () {

        //Alert
        if (distance < alertDist && distance>attackDist)
        {
            //activate is following state and disable is wandering state
            state.SetBool("isFollowing", true);
            state.SetBool("isWandering", false);

        }
        //Attacking
        else if (distance <= alertDist)
        {
            direction = player.position - transform.position;
            direction.y = 0;
            //
            Debug.Log("following the player");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.09f * Time.deltaTime);

            transform.Translate(Vector3.forward * speed / Time.deltaTime);

            
            state.SetBool("isFollowing", true);
            state.SetBool("isAttacking", false);
            state.SetBool("isWandering", false);

            if (direction.magnitude <= attackDist)
            {
                state.SetBool("isFollowing", false);
                state.SetBool("isAttacking", true);

            }
        }
        else if (distance > alertDist)
        {
            timer += Time.deltaTime;
            // 
            Debug.Log("player left alert distance");

            state.SetBool("isFollowing", false);
            state.SetBool("isAttacking", false);
            state.SetBool("isWandering", true);
            if (timer>= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }

        }

	}
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;

    }
}
