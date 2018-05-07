using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int playerHealth;
    public GameObject gameOver;
    public Text hitPoints;
    public GameObject lowHealth;
    public GameObject reload;
    
   
    public void TakeDamage(int damageAmount)
    {
        // as long as there is a player
        if (gameObject != null)
        {
            // subtract the damage amount from the players health
            playerHealth -= damageAmount;
            // update the health text by converting the players health to string and setting the hitPoint text to it
            hitPoints.text = playerHealth.ToString();
            // adjust the color of the hidden panel to apply a damage effect based on the amount of health the player has left using a switch statement
            switch (playerHealth)
            {
                // once the player reaches 40 health
                case 40:
                    // activate the panel
                    lowHealth.SetActive(true);
                    // set the panel's alpha to .2f
                    lowHealth.GetComponent<CanvasGroup>().alpha = .2f;
                    // stop the code from continuing on
                    break;
                // once the player is at 30 health
                case 30:
                    // set the panel's alpha to .5f
                    lowHealth.GetComponent<CanvasGroup>().alpha = .5f;
                    // stop the code from continuing on
                    break;
                // once the player is down to 20 health
                case 20:
                    // set the panel's alpha to .8f
                     lowHealth.GetComponent<CanvasGroup>().alpha = .8f;
                    // stop the code from continuing on
                    break;
                // once the player is down to 10 health
                case 10:
                    // set the panel's alpha to 1f
                     lowHealth.GetComponent<CanvasGroup>().alpha = 1f;
                    // stop the code from continuing on
                    break;
                    
                
            }
            // if the player has no more health
            if (playerHealth <= 0)
            {
                // destroy the player
                Destroy(gameObject);
                // set the health to 0
                playerHealth = 0;
                // hide the reload screen if it is active
                reload.SetActive(false);
                // show the gameover screen
                gameOver.SetActive(true);
                
            }
        }
        
       
    }







}// end







