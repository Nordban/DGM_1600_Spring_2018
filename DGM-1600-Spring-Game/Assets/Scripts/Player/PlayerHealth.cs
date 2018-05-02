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
        if (gameObject != null)
        {
            playerHealth -= damageAmount;
            hitPoints.text = playerHealth.ToString();
            
            if (playerHealth == 40)
            {
            lowHealth.SetActive(true);
            lowHealth.GetComponent<CanvasGroup>().alpha = .2f;
        }
            else if (playerHealth == 30)
            {
                lowHealth.GetComponent<CanvasGroup>().alpha = .5f;
            }
            else if (playerHealth == 20)
            {
                lowHealth.GetComponent<CanvasGroup>().alpha = .8f;
                
            }
            else if (playerHealth == 10)
            {
                lowHealth.GetComponent<CanvasGroup>().alpha = 1f;
            }
            if (playerHealth <= 0)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
                playerHealth = 0;
                reload.SetActive(false);
                gameOver.SetActive(true);
                
            }
        }
        
       
    }







}// end







