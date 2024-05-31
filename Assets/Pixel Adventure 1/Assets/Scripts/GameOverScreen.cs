using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    Scene currentScene;
    string sceneName;
    void Start()
    {

        currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;

   
    }
    public void setUp()
    {
       gameObject.SetActive(true);
    }

    public void restartButton()
    {
        
        SceneManager.LoadScene(sceneName);
    }
 
}
