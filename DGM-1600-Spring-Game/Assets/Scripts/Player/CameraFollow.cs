using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float cameraDistance = 10f;

    private void LateUpdate()
    {
        if (player != null)
        {
            // set the transform position of the camera to be behind the players transform position by the camera distance.
            transform.position = player.transform.position - player.transform.forward * cameraDistance;
            // use the .LookAt function to focus the camera on the position of the players transform
            transform.LookAt(player.transform.position);
            // calculate a new Vector3 each time the player moves to keep the camera behind the player
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
        
    }











}// end















