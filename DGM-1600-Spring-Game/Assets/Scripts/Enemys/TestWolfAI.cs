using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWolfAI : MonoBehaviour {
    // Public 
    public ChickenHealth chickenHealth;
    public PlayerHealth playerHealth;
    public GameObject myTarget;
    public int killedChickens;
    public GameObject warewolfPrefab;     
    public float speed;
    public int damage;
    public int deltDamage = 10;

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
    private float lookDist;   
    private GameObject warewolf;



    void OnEnable()
    {
        // get the navmesh agent component 
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // set the timer to wanderTimer
        timer = wanderTimer;
        // set attack timer to 0
        attackTimer = 0f;
    }
    // Use this for initialization
    void Start()
    {
        // get the wolf animatior component 
        state = GetComponent<Animator>();
        // get the player health script
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
                // change the wolf's state to following
                state.SetBool("isFollowing", true);
                state.SetBool("isWandering", false);
                state.SetBool("isAttacking", false);
                // increase the wolf's speed
                speed = speed + 2;
                // make the wolf look at the target transform
                transform.LookAt(myTarget.transform);
                // move the wolf towards the target
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            //Attacking
            else if (lookDist <= attackDist)
            {
                //print("Wolf is following!");
                // set the direction of the wolf to where the target transform is
                direction = myTarget.transform.position - transform.position;
                direction.y = 0;

              

                // change the wolf's state to attacking
                state.SetBool("isFollowing", false);
                state.SetBool("isAttacking", true);
                state.SetBool("isWandering", false);
                // reduce the speed to keep wolf from running into the game objects it is attacking
                speed = speed - 10;
                // prevent wolf speed from going too far negitive
                if (speed < -20)
                {
                    speed = 0;

                    transform.LookAt(myTarget.transform);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                    // if the wolf is close enougn to attack
                    if (direction.magnitude <= attackDist)
                    {
                        //print("wolf is attacking!");
                        state.SetBool("isFollowing", false);
                        state.SetBool("isAttacking", true);
                        state.SetBool("isWandering", false);
                        // get the game object from myTarget and assign it to the variable hit
                        var hit = myTarget.gameObject;

                        // wolf if attacking a chicken and gets the chickenhealth script and passes damage to it
                        if (myTarget.name == "Chicken(Clone)")
                        {
                            // get the chicken health script for the current target
                            chickenHealth = myTarget.GetComponent<ChickenHealth>();
                            // 
                            var health = hit.GetComponent<ChickenHealth>();
                            // if the chicken has health
                            if (health != null)
                            {
                                // start attack timer
                                StartCoroutine("AttackTimer");

                            }
                            else
                            {
                                // stop the attack timer cause the chicken is dead
                                StopCoroutine("AttackTimer");
                                // set the attack timer to 0
                                attackTimer = 0;
                                // set chickenHealth to null
                                chickenHealth = null;
                            }
                            
                           
                        }
                        // wolf is attacking player and gets the PlayerHealth script and passes damage through it
                        else if( myTarget.name == "Farmer" )
                        {
                            
                            // get the player health script
                            playerHealth = hit.GetComponent<PlayerHealth>();
                           
                            // if the player still has health and the would is closer or equal to the attack distance start the attack timer
                            if (playerHealth != null && direction.magnitude <= attackDist)
                            {
                                // start the attack timer
                                StartCoroutine("AttackTimer");
                                

                            }
                            else 
                            {
                                // stop the attack timer and set timer to = 0
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
                // set target to null
                 myTarget = null;

                //Wandering
                if (myTarget == null)
                {
                    // increase the timer
                    timer += Time.deltaTime;
                    // change the wolf's state to wandering
                    state.SetBool("isFollowing", false);
                    state.SetBool("isAttacking", false);
                    state.SetBool("isWandering", true);

                    if (timer >= wanderTimer)
                    {
                        // make the wolf wander
                        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                        agent.SetDestination(newPos);
                        timer = 0;
                    }


                }
            }
       

          


        }

       
    }


    // set the would to a random direction 
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

        // attack timer
    IEnumerator AttackTimer()
    {
        // as long as the timer is not 0
        while (timer != 0)
        {
            // as long as the attack timer is <= 0 
            while (attackTimer <= 0)
            {
                // if mytarget isn't null and it's name is "Farmer"
                if (myTarget != null && myTarget.name == "Farmer")
                {
                    // pass damage to the playerHealth script
                    playerHealth.TakeDamage(damage);
                }
                // if myTarget isn't null and it's name is "Chicken(Clone)"
                else if (myTarget != null && myTarget.name == "Chicken(Clone)")
                {
                    // Pass damage to the chickenHealth script
                    chickenHealth.TakeDamage(damage);
                }
                else
                {
                    // just in case
                    myTarget = null;
                }
                // reset timer
                attackTimer = 1f;
                
            }

            // decrease timer amount
            attackTimer -= Time.deltaTime;


            // wait till the timer reaches 0
            yield return new WaitForSeconds(attackTimer);



        }
    }


}//class









