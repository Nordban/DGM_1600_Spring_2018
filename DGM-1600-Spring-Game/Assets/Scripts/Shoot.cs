using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    
    public Rigidbody projectile;
    public Transform shootPoint;
    public float shootSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("fired bullet");
            Rigidbody clone;

            // instanciate (object you want instanceiated, where you want it instancated, rotation of object)

            clone = (Rigidbody)Instantiate(projectile, shootPoint.position , projectile.rotation);

            clone.velocity = shootPoint.TransformDirection(Vector3.forward * shootSpeed * Time.deltaTime);
        }
	}
}
