using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    private string nextLevelName;
    private int currentLevel;

    //Recuperer le num du level
    private int GetLevelNumberFromSceneName(string sceneName)
    {
       
        Match match = Regex.Match(sceneName, @"\d+");
        if (sceneName == "Level_Intro")
        {
            return 0;
        }
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        else
        {
            Debug.LogError("Failed to parse level number from scene name: " + sceneName);
            return 0; // Default to level 1 if parsing fails
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
      {
        Debug.Log("Trigger entered by: " + collision.name);
        if (collision.CompareTag("WaterGirl"))
          {
            Debug.Log("WaterGirl detected, changing level...");
            ChangeLevel();
          }
        }

    void Start()
    {
        // Extract the current level number from the scene name
        currentLevel = GetLevelNumberFromSceneName(SceneManager.GetActiveScene().name);
    }



    private void ChangeLevel()
    {   if(currentLevel == 0)
        {
            nextLevelName = "Level_1";
        }
        nextLevelName= "Level_" + (currentLevel + 1).ToString();
        if (string.IsNullOrEmpty(nextLevelName))
        {
            Debug.LogError("Next level name is empty or null!");
            return;
        }

        Debug.Log("Loading level: " + nextLevelName);
        if (Application.CanStreamedLevelBeLoaded(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            Debug.LogError("Level " + nextLevelName + " cannot be loaded. Make sure it is added to the Build Settings.");
        }
    }
}
