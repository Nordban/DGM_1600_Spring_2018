using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaning : MonoBehaviour {


    public GameObject[] spawnPoints;
    
    public GameObject chicken;
	// Use this for initialization
	void Start () {
        // find all gameObjects with the tag respawn
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");

        //chicken = GameObject.Find("Chicken");d
        // load chickens
        chicken = (GameObject)Resources.Load("Chicken", typeof(GameObject));

        // currentChickens = maxChickens;
        //Spawn Chicken
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
        //if (currentChickens < maxChickens)
        //{
        //    Spawn();
        //}
       
	}

    //Function to spawn chicken
    void Spawn()
    {
        int spawn = UnityEngine.Random.Range(0, spawnPoints.Length);

        GameObject.Instantiate(chicken, spawnPoints[spawn].transform.position, Quaternion.identity);
    }
}
