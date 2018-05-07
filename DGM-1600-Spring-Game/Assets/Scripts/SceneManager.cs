using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManager : MonoBehaviour {

    // load the level 
    public void LoadScene(int lvl)
    {
        // load the level of the corresponding number, number references the scenes in build number
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(lvl);
    }
}
