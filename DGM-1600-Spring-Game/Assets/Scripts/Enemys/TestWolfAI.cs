using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWolfAI : MonoBehaviour {
    // Public 
   // public Transform player;
    public float speed;
    public int damage;
    // Wander 
    public float wanderRadius;
    public float wanderTimer;
    //Detection 
    public float alertDist;
    public float attackDist;
    // Private 
    private Animator state;
    private Vector3 direction;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;
    private float distance;
    private float attackTimer;
    



    public int deltDamage = 10;
    private float lookDist;
    public ChickenHealth chickenHealth;
    public PlayerHealth playerHealth;
    public GameObject myTarget;
    public int killedChickens;
    public GameObject warewolfPrefab;
    private GameObject warewolf;



    void OnEnable()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
        attackTimer = 1f;
    }
    // Use this for initialization
    void Start()
    {
        state = GetComponent<Animator>();
        playerHealth = Object.FindObjectOfType<PlayerHealth>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

        // create an array of gameobjects with target tag
        var targets = GameObject.FindGameObjectsWithTag("Target");
        //calculate which of these objects is closer

        // if there are available targets
        if (targets.Length > 0)
        {
            // set distance to look for targets within aleart range
            lookDist = 50f;

            //cycle through targets to find the closest one
            foreach (var enemy in targets)
            {
                // use Vector3.Distance to caculate wolf's distance from each target
                distance = Vector3.Distance(enemy.transform.position, transform.position);

                // if there is a target within alert distance set as target
                if (distance < lookDist)
                {
                    lookDist = distance;
                    myTarget = enemy;

                    //if (myTarget.name == "Chicken(Clone")
                    //{
                    //    Debug.Log("got the nearest chicken's health script");
                    //    chickenHealth = myTarget.GetComponent<ChickenHealth>();
                    //}
                    
                }
                // log current target **for testing only**
                //if (myTarget == enemy)
                //{
                //    Debug.Log("my closest target is " + myTarget.transform.name);
                //}

            }

           

            // Alert
            if (lookDist < alertDist && lookDist > attackDist)
            {
                //print("Wolf sees player");
                state.SetBool("isFollowing", true);
                state.SetBool("isWandering", false);
                state.SetBool("isAttacking", false);
                speed = speed + 2;
                transform.LookAt(myTarget.transform);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            //Attacking
            else if (lookDist <= alertDist)
            {
                print("Wolf is following!");
                direction = myTarget.transform.position - transform.position;
                direction.y = 0;

              


                state.SetBool("isFollowing", false);
                state.SetBool("isAttacking", true);
                state.SetBool("isWandering", false);

                speed = speed - 10;
                if (speed < -20)
                {
                    speed = 0;

                    transform.LookAt(myTarget.transform);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);

                    if (direction.magnitude <= attackDist)
                    {
                        print("wolf is attacking!");
                        state.SetBool("isFollowing", false);
                        state.SetBool("isAttacking", true);
                        state.SetBool("isWandering", false);
                        var hit = myTarget.gameObject;

                        // wolf if attacking a chicken and gets the chickenhealth script and passes damage to it
                        if (myTarget.name == "Chicken(Clone)")
                        {
                            chickenHealth = myTarget.GetComponent<ChickenHealth>();
                            var health = hit.GetComponent<ChickenHealth>();
                            if (health != null )
                            {
                                
                                StartCoroutine("AttackTimer");

                            }
                            else
                            {
                                StopCoroutine("AttackTimer");
                                attackTimer = 0;
                                chickenHealth = null;
                            }
                        }
                        // wolf is attacking player and gets the PlayerHealth script and passes damage through it
                        else if( myTarget.name == "Farmer" )
                        {
                            
                            
                            playerHealth = hit.GetComponent<PlayerHealth>();
                            attackTimer -= Time.deltaTime;
                            //Debug.Log(attackTimer);
                            if (playerHealth != null && direction.magnitude <= attackDist)
                            {
                                StartCoroutine("AttackTimer");
                                

                            }
                            else 
                            {
                                StopCoroutine("AttackTimer");
                                attackTimer = 0;
                                playerHealth = null;
                            }
                        }
                    }
                
                }

            }
            else
            {
                 myTarget = null;
                //Wandering
                if (myTarget == null)
                {
                    timer += Time.deltaTime;

                    state.SetBool("isFollowing", false);
                    state.SetBool("isAttacking", false);
                    state.SetBool("isWandering", true);

                    if (timer >= wanderTimer)
                    {
                        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                        agent.SetDestination(newPos);
                        timer = 0;
                    }


                }
            }
       

          


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

    //This would have spawned a warewolf at the current transform position of the wolf and destroyed the wolf object if the wolf ate 3 chickens but I was unable to 
    //get the chickens to pass a value to this function with the OnDestroy function or just before i destroyed the chicken object.
    //public void ChickensKilled(int chickens)
    //{
    //    killedChickens += chickens;
    //    Debug.Log(killedChickens);
    //    if (killedChickens >= 3)
    //    {

    //        warewolf = (GameObject)GameObject.Instantiate(warewolfPrefab, transform.position, Quaternion.identity);
    //        //Instantiate(warewolf, gameObject.transform, true);
    //        Debug.Log("warewolf spawned");

    //        Destroy(gameObject);
    //    }
    //}


    IEnumerator AttackTimer()
    {
        while (timer != 0)
        {

            while (attackTimer <= 0)
            {
                if (myTarget != null && myTarget.name == "Farmer")
                {
                    playerHealth.TakeDamage(damage);
                }
                else if (myTarget != null && myTarget.name == "Chicken(Clone)")
                {
                    chickenHealth.TakeDamage(damage);
                }
                else
                {
                    myTarget = null;
                }
                
                attackTimer = 1f;
                //Debug.Log("reset timer");
            }

            attackTimer -= Time.deltaTime;



            yield return new WaitForSeconds(attackTimer);



        }
    }


}//class









