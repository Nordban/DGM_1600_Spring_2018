using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour {

    public Rigidbody projectile;
    public Transform shootPoint;
    public float shootSpeed;   
    public int maxBullets;
    public Text bulletCount;
    public GameObject reloadPanel;


    private int bullets;
    // Use this for initialization
    void Start()
    {
        
        bulletCount.text = maxBullets.ToString();
        reloadPanel.SetActive(false);
        bullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        // set the shoot key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // set the current bullet amount to the hud text
            bulletCount.text = bullets.ToString();
            // decrease the bullet count when shoot button is pressed
            bullets--;

            if (bullets >= 0)
            {
               
                Debug.Log("fired bullet");
                Rigidbody clone;

                // instanciate (object you want instanceiated, where you want it instancated, rotation of object)
                //spawn the bullet
                clone = (Rigidbody)Instantiate(projectile, shootPoint.position, projectile.rotation);
                // set the velocity for the bullet
                clone.velocity = shootPoint.TransformDirection(Vector3.forward * shootSpeed * Time.deltaTime);
            }            
            else
            {
                // keep bullet count at 0
                bullets = 0;
                //show the reload prompt
                reloadPanel.SetActive(true);
            }
            
        }
    }
    //reload the gun when the player enters the barn sphere collider
    private void OnTriggerStay(Collider other)
    {
        //test if the collider belongs to the barn and bullets is < 14
        if (other.gameObject.name == "Barn" && bullets <=14)
        {
           // reset bullets to max
            bullets = maxBullets;
            //update bullet count text
            bulletCount.text = bullets.ToString();

            // hide the reload prompt
            reloadPanel.SetActive(false);
        }

    }





}// end












