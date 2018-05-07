using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour {

    public Button start, options, quit, goBack;
    public GameObject MainMenuPanel, OptionsPanel;

	// Use this for initialization
	void Start () {
        // get the button for start and assign it to newGame
        Button newGame = start.GetComponent<Button>();
        // get the button for options and assign it to gameOptions
        Button gameOptions = options.GetComponent<Button>();
        // get the button for quit and assign it to quitGame
        Button quitGame = quit.GetComponent<Button>();
        // get the button for goBack and assign it to back
        Button back = goBack.GetComponent<Button>();
        // hide the options panel
        OptionsPanel.SetActive(false);
        // show the main menu
        MainMenuPanel.SetActive(true);

        // add onClick listeners for each of the buttons
        newGame.onClick.AddListener(Begin);
        gameOptions.onClick.AddListener(Options);
        back.onClick.AddListener(GoBack);
        quitGame.onClick.AddListener(QuitGame);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Begin()
    {
        // load level one which is the game 
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }

    void Options()
    {
        // hide the main menu
        MainMenuPanel.SetActive(false);
        // display the options menu
        OptionsPanel.SetActive(true);
    }

    void GoBack()
    {
        // show the main menu
        MainMenuPanel.SetActive(true);
        // hide the options menu
        OptionsPanel.SetActive(false);
    }
    void QuitGame()
    {
        // close the application
        Application.Quit();
    }






}// class







