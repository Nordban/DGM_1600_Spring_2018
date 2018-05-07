using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spwaning : MonoBehaviour {

    public ScoreManager scoreManagerScript;
    
    public GameObject[] spawnPoints;
    public float timer = 2f;
    public Text remainingChickens;
    public GameObject chickenClone;
    public int spawn;
    public GameObject chicken;
    public int cCount;

    private int chickenCount;
    private GameObject[] targets;


    private void Awake()
    {
        // get the scoreManager script
        scoreManagerScript = FindObjectOfType<ScoreManager>();


    }

    // Use this for initialization
    void Start () {
        // I do this here so there is at least one chicken spawned at the beginning of the game
        // get the number of maxchickens
        chickenCount = scoreManagerScript.maxChickens;
        //Debug.Log(chickenCount);
        // get the model for the chicken
        chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));
        // instantiate the chicken clone
        chickenClone = Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity);
        // reduce the chicken count.
        chickenCount--;
        // attach the chickenHealth script
        chickenClone.AddComponent<ChickenHealth>();
        // set the timer for the next spawn
        timer = 1f;
      
        // find all gameObjects with the tag respawn
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
             
    }
	
	// Update is called once per frame
	void Update ()
    {
        // find all gameobjects that have the tag targets, and put them into an array
        targets = GameObject.FindGameObjectsWithTag("Target");

        // get the length of the array and store it in cCount
        cCount = targets.Length;
            
        // if the count is <= to the scorManagerScript.maxChickens amount or the count is > scoreManagerScript.maxChickens
        if (cCount <= scoreManagerScript.maxChickens || cCount > scoreManagerScript.maxChickens)
        {
            // set the length of the array to cCount
            cCount = targets.Length;
            // subtract 1 to account for the player that also has the Target tag
            int count = cCount - 1;
            // pass the number to the CountYourChickens function to keep track of the number of chickens we have
            CountYourChickens(count);
            //Debug.Log(cCount);
        }
            

        // if there are still chickens to spawn
        if (chickenCount >= 0 )
        {
            // start the coroutine and spawn some chickens
            StartCoroutine("SpawnChicken");
        }
        else
        {
            // stop the spawn coroutine
            StopCoroutine("SpawnChicken");
            //Debug.Log("stopping coroutine");

            // reset the timer
            timer = 0;
        }
       
        

    }
    // keep track of the number of chickens left in the game
    public void CountYourChickens(int chicken)
    {
        // convert the int to a string and update the remainingChickens text 
        remainingChickens.text = chicken.ToString();
    }

    IEnumerator SpawnChicken()
    {
        // as long as the timer is not 0
        while (timer != 0)
        {
            // as long as there are chickens and the timer is <= 0  spawn a chicken
            while (chickenCount > 0 && timer <= 0)
            {
                // get a random number based on the number of spawn points
                spawn = UnityEngine.Random.Range(0, spawnPoints.Length);
                // instantiate a chicken clone at the spawnpoint in the array that is the same as the randomly generated number
                chickenClone = Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity) as GameObject;
               // attach the chickenHealth scrip to the chicken
                chickenClone.AddComponent<ChickenHealth>();
                // reduce the chickenCount
                chickenCount--;
               // Debug.Log("spawned a Chicken");
               // reset the timer
                timer = 3f;
                //Debug.Log("reset timer");
            }

            // count the timer down
            timer -= Time.deltaTime;

           
            // wait for the timer to be 0
            yield return new WaitForSeconds(timer);



        }
    }
  







}// end













