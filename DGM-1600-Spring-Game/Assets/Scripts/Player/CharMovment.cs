using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovment : MonoBehaviour {
    

    public float inputDelay = 0.1f;
    public float forwardVel = 12f;
    public float rotateVel = 100;
   

    private Quaternion targetRotation;
    private CharacterController cController;
    private float forwardInput;
    private float turnInput;
   
   


    //private PlayerMotor motor;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

	// Use this for initialization
	void Start () {
        targetRotation = transform.rotation;
        // test to see if a character controller is attached to the gameobject
        if (GetComponent<CharacterController>())
        {
            cController = GetComponent<CharacterController>();
        }
        else
        {
            Debug.Log("There is no character controller attached to the object");
        }
        
        forwardInput = 0;
        turnInput = 0;

    }
   
	
	// Update is called once per frame
	void Update () {
        
        GetInput();
        Turn();
        
       
    }
   
    private void FixedUpdate()
    {
        Run();
    }
    // Get input for the vertical and horizontal axis
    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput)> inputDelay)
        {
            //Testing
            cController.SimpleMove(transform.forward * forwardInput * forwardVel);
        }
        else
        {
            cController.SimpleMove(Vector3.zero);
        }
    }
    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
            //transform.rotation = targetRotation;
            cController.transform.rotation = targetRotation;
        }
    }

  










}//end





