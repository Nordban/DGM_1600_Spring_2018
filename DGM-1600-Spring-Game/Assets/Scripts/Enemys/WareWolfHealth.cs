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
        currentHealth = maxHealth;
        dead = 1;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // keep score at zero
            currentHealth = 0;
            

            // add points for killing wolf
            ScoreManager.AddPoints(points, dead);
            
            //Instantiate(warewolf, gameObject.transform, true);
            //Debug.Log("warewolf spawned");

            Destroy(gameObject);

           
        }
    }
}
