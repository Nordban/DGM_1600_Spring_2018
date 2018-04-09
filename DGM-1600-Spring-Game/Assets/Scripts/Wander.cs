using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    public float moveSpeed;
    public Transform target;

    //public int damage;

    //public GameObject pcHealth;
	// Use this for initialization

        void Wandering()
    {
         //print("chicken is wandering");

        //makes the animal wander
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // create a random number to randomize rotation
        int randomNum = Random.Range(0, 360);

        // set the transform of chicken to allways face foward
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // shoot raycaster 
        RaycastHit hit;

        // draw the ray
        Debug.DrawRay(transform.position, fwd * 3, Color.red);

        if (Physics.Raycast(transform.position,fwd,out hit, 3)) 
        {
            //
            if (hit.collider.tag == "Wall")
            {
                transform.Rotate(0, randomNum, 0);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("player stinks");
        }
        else
        {
            Wandering();
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
