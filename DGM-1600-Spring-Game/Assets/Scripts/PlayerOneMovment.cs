using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovment : MonoBehaviour {

    public float transX;
    public float transY;
    public float transZ;

    public float rotX;
    public float rotY;
    public float rotZ;

    public string firstName = "";

    private double cheeseBurger = 0.5;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate ( transX, transY, transZ);
        transform.Rotate(rotX, rotY, rotZ);

    }
}
