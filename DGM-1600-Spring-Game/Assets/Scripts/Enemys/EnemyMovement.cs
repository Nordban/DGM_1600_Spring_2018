using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {







                        /* * * * * * * * * * * * * * * * * * * * * * *  NOTE * * * * * * * * * * * * * * * * * * * * * * * * */



   /* This script is one I wrote while following a tutorial from a course I bought on Udemy. The majority of the code was given by the instructor throughtout the videos
    * of his course and I adapted them to this game. currently this script is not being used as I only have it attached to a warewolf gameobject that i also got from
    * that Udemy course. I was not able to get the warewolf to work the way I wanted to so this is not currently attached to any gameobjects in my game.
    * That being said the code works as i intended it to so i left it in. But because it was typed as i followed the tutorial i wanted to make a note of it. */








    public float gravityMultiplier = 1f;
    public float lerpTime = 10f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 targetDirection = Vector3.zero;
    private float fallVelocity = 0f;


    [HideInInspector] // hides the public variable in unity's inspector so that it can't be manipulated in the inspector but still be public
    public CharacterController charController;

    public float distanceToGround = 0.1f;
    private bool isGrounded;
    private Collider myCollider;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider>();

    }

    // Use this for initialization
    void Start()
    {
        //use to calculate distance to the ground
        distanceToGround = myCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        

        // use Vector3.Lerp to smooth out the fall 
        moveDirection = Vector3.Lerp(moveDirection, targetDirection, Time.deltaTime * lerpTime);
        // asign the fallVelocity to moveDirection.y so only the y axis is changed
        moveDirection.y = fallVelocity;
        //multiply the .Move function by Time.deltaTime to elimanate processer speeds
        charController.Move(moveDirection * Time.deltaTime);

    }
   
    /// <summary>
    /// used to move the player from another script
    /// </summary>
    /// <param name="dir"></param>
    public void Move(Vector3 dir)
    {
        targetDirection = dir;
    }
    public void Stop()
    {
        moveDirection = Vector3.zero;
        targetDirection = Vector3.zero;
    }
 


}//end







