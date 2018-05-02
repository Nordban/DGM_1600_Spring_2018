using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NavWander : MonoBehaviour {

    public float wanderRadius;  
    public float wanderTimer;

    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    
    public int points;
    public bool isWandering = true;


    private void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }

    private void Start()
    {
        wanderTimer = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
	}
    private void LateUpdate()
    {
        if (wanderTimer<= 0)
        {
            StartCoroutine("RandomWander");
        }
       
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    IEnumerator RandomWander()
    {
        wanderTimer = Random.Range(1, 5);
        yield return new WaitForSeconds(wanderTimer);
    }
}
