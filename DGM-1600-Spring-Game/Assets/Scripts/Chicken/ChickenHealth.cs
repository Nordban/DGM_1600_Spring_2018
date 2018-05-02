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
        //deadChicken = 1;
        //wolf = GameObject.FindGameObjectWithTag("Enemy");
       

        //attempting to get the wolf object so i can pass a value to the chickensKilled function
       //wolfAiScript = Object.FindObjectOfType<TestWolfAI>();
        
    }

    //private void Update()
    //{
    //    if (wolf != null)
    //    {
    //        // get the gameobject that has entered the chickens alert zone and assign it to the wolf variable
    //        wolf = GetComponent<ChickenAI>().enemy;

    //        // get the updatedWolfNavMeshAI script from the target in order to pass the deadChicken value to the correct wolf if the chicken dies.
           
    //    }
    //    else
    //    {
    //        wolf = null;
    //    }
        
       
    //}
    // keep track of the damage done to chicken. once health gets to 0 or below destroy the chicken
    public void TakeDamage(int damageAmount)
    {
    
        chickenHealth -= damageAmount;
        if (chickenHealth <= 0 && gameObject != null)
        {
           
            //Debug.Log(deadChicken);
            Destroy(gameObject);
            chickenHealth = 0;
            
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













