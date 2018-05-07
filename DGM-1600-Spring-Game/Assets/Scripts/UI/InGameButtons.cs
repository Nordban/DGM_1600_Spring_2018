using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour {

    public Button  lStart, lMainMenu, wStart, wMainMenu;
   

    // Use this for initialization
    void Start()
    {
        // get buttons from loose panel
        Button lPlayAgain = lStart.GetComponent<Button>();
        Button lBack = lMainMenu.GetComponent<Button>();

        //get buttons from win panel
        Button wPlayAgain = wStart.GetComponent<Button>();
        Button wBack = wMainMenu.GetComponent<Button>();
       
        // add onClick listeners for each of the buttons
        lPlayAgain.onClick.AddListener(Begin);       
        lBack.onClick.AddListener(MainMenu);
        wPlayAgain.onClick.AddListener(Begin);
        wBack.onClick.AddListener(MainMenu);
    }

    // Update is called once per frame
   
    void Begin()
    {
        // load the game
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }

    void MainMenu()
    {
        // load the main menu
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
    }
}
