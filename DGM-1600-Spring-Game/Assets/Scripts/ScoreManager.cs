using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int wolfKilled;


    public int finalScore;
    public Text remainingChickensText;
    public Text finalScoreText;
    public Text wolvesKilled;
    public int maxChickens;
    public GameObject winPanel;
    public GameObject reload;


    private GameObject[] enemies;
    private GameObject[] chickens;
    
    void Awake()
    {
        maxChickens = 10;
        Time.timeScale = 1;
    }
    // Use this for initialization
    void Start()
    {
       
            
        // find the enemies at the start of the game
        enemies = GameObject.FindGameObjectsWithTag("Wolf");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Wolf");
        // if you killed all the enemies
        if (enemies.Length <= 0 )
        {
            // find all objects with the tag target and put them in an array
            chickens = GameObject.FindGameObjectsWithTag("Target");
            // assign the length of the array to local variable 
            int test = chickens.Length;

            if (test > maxChickens)
            {
                // make it so that test is never > maxChickens
                test = maxChickens;
            }
            // account for the player which also has the target tag
            int finalChickens = test - 1;
            // caculate the final score
            finalScore = finalChickens * score;
            // update the remaining chickens text by converting the final chickens to type string 
            remainingChickensText.text = finalChickens.ToString();
            // Update the final score text by converting the finalScore variable to type string
            finalScoreText.text = finalScore.ToString();
            // Updated the wolves killed text by converting the wolfKilled value to type string
            wolvesKilled.text = wolfKilled.ToString();
            // disable the reload panel if it is active
            reload.SetActive(false);
            // activate the winPanel
            winPanel.SetActive(true);
            //Pause the game
            Time.timeScale = 0;
            
        }
        else
        {
            // disable the win panel 
            winPanel.SetActive(false);
        }
       

        
    }
    // get the points and keep track of how many wolves have been killed
    public static void AddPoints(int pointsToAdd, int deadWolf)
    {
        // add any incoming score to what is already there
        score += pointsToAdd;
        // add any incoming wolves to what is already there
        wolfKilled += deadWolf;
    }
    // reset the score
    public void Reset()
    {
        score = 0;
    }







}// class






