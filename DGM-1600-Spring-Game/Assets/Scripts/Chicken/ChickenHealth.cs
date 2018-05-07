using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenHealth : MonoBehaviour {

    public int chickenHealth;

   
    //public TestWolfAI wolfAiScript;
    //private int deadChicken;
    //public GameObject wolf;

    

    
    private void Start()
    {   
        // set the chickens health
        chickenHealth = 30;

        
    }
    
    // keep track of the damage done to chicken. once health gets to 0 or below destroy the chicken
    public void TakeDamage(int damageAmount)
    {
        // take damage from the chicken's health
        chickenHealth -= damageAmount;
        // if the chicken has <=0 health
        if (chickenHealth <= 0)
        {

            //Debug.Log(deadChicken);
            // set the chicken's health to 0
            chickenHealth = 0;
            // destroy the chicken
            Destroy(gameObject);
            




        }
       
    }
    // when this chicken is destroyed assign dead chicken a value of one and pass it to the destroying wolf's killed chicken count
    // at least that is what was supposed to happen. but it didn't so i am comenting it out till i can work it out
    //void OnDestroy()
    //{

    //    Debug.Log(wolf);
    //    if (wolf != null)
    //    {


    //        wolfAiScript.ChickensKilled(deadChicken);
           

    //    }
    //    else
    //    {
    //        wolf = null;
    //    }

    //}



}//Class













