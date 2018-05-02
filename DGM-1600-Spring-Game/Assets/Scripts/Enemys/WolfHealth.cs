using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    private int points;
    private int dead;
    


	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        // set point amount
        points = 100;

        // set amount to keep track of wolves killed for scoring.
        dead = 1;
	}
	
	public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
           // set health to 0
            currentHealth = 0;
            

            // add points for killing wolf
            ScoreManager.AddPoints(points, dead);
            //Debug.Log("adding points " + points);
            

            //destroy wolf
            Destroy(gameObject);
                        
        }
    }
}
