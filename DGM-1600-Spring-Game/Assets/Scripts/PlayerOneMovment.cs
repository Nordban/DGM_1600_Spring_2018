using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovment : MonoBehaviour {


    //public float transX;
    //public float transY;
    //public float transZ;

    //public float rotX;
    //public float rotY;
    //public float rotZ;
    //public Vector3 move;
    public float move;
    public float rotate;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate ( transX, transY, transZ);
        //transform.Rotate(rotX, rotY, rotZ);
        //access cubes translate on x,y,z axis
        

        if (Input.GetKey(KeyCode.UpArrow))
        {
           
            transform.Translate(Vector3.left * move * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            transform.Translate(Vector3.right * move * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotate * Time.deltaTime *10, 0);
        //transform.rotation = Quaternion.Euler(0,-rotate * Time.deltaTime,0);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotate * Time.deltaTime * 10, 0);
            //transform.rotation = Quaternion.Euler(0, rotate * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * move * Time.deltaTime);
        }
    }
}