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
        Button newGame = start.GetComponent<Button>();
        Button gameOptions = options.GetComponent<Button>();
        Button quitGame = quit.GetComponent<Button>();
        Button back = goBack.GetComponent<Button>();
        OptionsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);

        
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
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }

    void Options()
    {
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    void GoBack()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }
    void QuitGame()
    {
        Application.Quit();
    }






}// class







