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
    private GameObject[] enemies;
    private GameObject[] chickens;
    public GameObject reload;
    void Awake()
    {
        maxChickens = 10;
        Time.timeScale = 1;
    }
    // Use this for initialization
    void Start()
    {
       
        //winText.GetComponent<Text>().enabled = false;
        //text = GetComponent<Text>();
        //score = 0;
        

        enemies = GameObject.FindGameObjectsWithTag("Wolf");
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Wolf");
        if (enemies.Length <= 0 )
        {

            chickens = GameObject.FindGameObjectsWithTag("Target");
            int test = chickens.Length;
            if (test > maxChickens)
            {
                test = maxChickens;
            }
            int finalChickens = test - 1;

            finalScore = finalChickens * score;

            remainingChickensText.text = finalChickens.ToString();

            finalScoreText.text = finalScore.ToString();

            wolvesKilled.text = wolfKilled.ToString();
            reload.SetActive(false);
            winPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log(score);
        }
        else
        {
            winPanel.SetActive(false);
        }
        //if (score < 0)
        //{
        //    score = 0;
        //    text.text = "" + score;

         

        //}

        
    }
    public static void AddPoints(int pointsToAdd, int deadWolf)
    {
        score += pointsToAdd;
        wolfKilled += deadWolf;
    }
    
    public void Reset()
    {
        score = 0;
    }

}
