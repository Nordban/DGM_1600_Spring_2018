using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;

    public int winScore;
    public Text text;
    public Text winText;


    void Awake()
    {
        Time.timeScale = 1;
    }
    // Use this for initialization
    void Start()
    {
        winText.GetComponent<Text>().enabled = false;
        text = GetComponent<Text>();
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (score < 0)
        {
            score = 0;
            text.text = "" + score;

            // if the player wins display win text
            if (winScore == score)
            {
                print("Win Score Reached = " + score);
                winText.GetComponent<Text>().enabled = true;

                Time.timeScale = 0;

            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }

        
    }
    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }
    public void Reset()
    {
        score = 0;
    }
}
