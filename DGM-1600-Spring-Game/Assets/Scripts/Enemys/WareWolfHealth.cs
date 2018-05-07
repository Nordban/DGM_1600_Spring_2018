using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareWolfHealth : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    private int points;
    private int dead;



    // Use this for initialization
    void Start()
    {
        // set the current health to the max health
        currentHealth = maxHealth;
        // set the number to be passed once the warewolf dies
        dead = 1;
        // set the number of points for killing the warewolf
        points = 200;
    }

    public void TakeDamage(int amount)
    {
        // subtract the damage from the health
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // set health to 0
            currentHealth = 0;
            

            // add points for killing wareWolf
            ScoreManager.AddPoints(points, dead);
            
            
            // destroy wareWolf
            Destroy(gameObject);

           
        }
    }
}
