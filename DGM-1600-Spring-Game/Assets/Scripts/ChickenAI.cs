using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour {
    //public Rigidbody enemy;
    public float moveSpeed;
    public Transform target;
    public Transform chickenPen;

    public int points = 10;



	// Use this for initialization
	void Start () {
		// chickenPen = GameObject.Fin
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player has entered chickens trigger");
            transform.LookAt(target);
            // need to rotate chicken 180 degrees 
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);

        }   
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            // send chicken to chicken pen.
            transform.position = chickenPen.position;
            transform.rotation = chickenPen.rotation;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
