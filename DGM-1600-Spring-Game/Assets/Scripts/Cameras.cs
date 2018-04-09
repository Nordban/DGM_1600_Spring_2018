using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject[] gameCameras;
    private int gameCameraIndex = 0;

    // Use this for initialization
    void Start()
    {
        FocusOnCamera(gameCameraIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            gameCameraIndex = 1;
            FocusOnCamera(gameCameraIndex);
        }
        else
        {
            gameCameraIndex = 0;
            FocusOnCamera(gameCameraIndex);
        }
    }
    // focus only on the active camera by using a for loop to cycle through the gameCameras array
    void FocusOnCamera(int index)
    {
        // loop through camera index
        for (int i = 0; i < gameCameras.Length; i++)
        {
            // set the active camera to which ever camera == index
            gameCameras[i].SetActive(i == index);

        }

        // function to increase or decrease gameCameraIdex on button press
        //void ChangeCamera(int direction)
        //{
        //    gameCameraIndex += direction;
        //    // reset camera index if index is increased passed array length.
        //    if (gameCameraIndex >= gameCameras.Length)
        //    {
        //        gameCameraIndex = 0;
        //    }
        //    if (gameCameraIndex < 0)
        //    {
        //        gameCameraIndex = gameCameras.Length - 1;
        //    }

        //    FocusOnCamera(gameCameraIndex);
        //}
    }
}
