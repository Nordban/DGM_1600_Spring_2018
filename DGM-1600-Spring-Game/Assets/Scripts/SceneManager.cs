using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour {



	// Use this for initialization
	void Start () {
        
	}

    public void LoadScene(int lvl)
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(lvl);
    }
}
