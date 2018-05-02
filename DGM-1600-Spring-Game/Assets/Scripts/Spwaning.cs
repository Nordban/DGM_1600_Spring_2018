using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spwaning : MonoBehaviour {

    public ScoreManager scoreManagerScript;
    private int chickenCount;
    public GameObject[] spawnPoints;
    public float timer = 2f;
    public Text remainingChickens;
    public GameObject chickenClone;
    public int spawn;
    public GameObject chicken;
    public int cCount;
    // public ChickenHealth cCount;
    private GameObject[] targets;
    private void Awake()
    {

        scoreManagerScript = FindObjectOfType<ScoreManager>();


    }

    // Use this for initialization
    void Start () {
        
        
        chickenCount = scoreManagerScript.maxChickens;
        Debug.Log(chickenCount);
        chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));

        chickenClone = Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity);
        chickenCount--;
        
        chickenClone.AddComponent<ChickenHealth>();

        timer = 2f;
        //cCount = GetComponent<ChickenHealth>();
        // find all gameObjects with the tag respawn
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
             
    }
	
	// Update is called once per frame
	void Update () {

        targets = GameObject.FindGameObjectsWithTag("Target");

             cCount = targets.Length;
            
        
            if (cCount <= scoreManagerScript.maxChickens|| cCount >scoreManagerScript.maxChickens)
            {
                cCount = targets.Length;
            int count = cCount - 1;
                CountYourChickens(count);
            Debug.Log(cCount);
        }
            


        if (chickenCount >= 0 )
        {
            StartCoroutine("SpawnChicken");
        }
        else
        {
            StopCoroutine("SpawnChicken");
            //Debug.Log("stopping coroutine");
            timer = 0;
        }
       
        

    }
    
    public void CountYourChickens(int chicken)
    {
        remainingChickens.text = chicken.ToString();
    }

    IEnumerator SpawnChicken()
    {
        while (timer != 0)
        {

            while (chickenCount > 0 && timer <= 0)
            {
                 spawn = UnityEngine.Random.Range(0, spawnPoints.Length);
                
                chickenClone = Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity) as GameObject;
               
                chickenClone.AddComponent<ChickenHealth>();
                chickenCount--;
               // Debug.Log("spawned a Chicken");
                timer = 5f;
                //Debug.Log("reset timer");
            }

            timer -= Time.deltaTime;

           

            yield return new WaitForSeconds(timer);



        }
    }
  







}// end













