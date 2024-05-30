using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
     private string nextLevelName = "Level_1";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered by: " + collision.name);
        if (collision.CompareTag("WaterGirl"))
        {
            Debug.Log("WaterGirl detected, changing level...");
            ChangeLevel();
        }
    }

    private void ChangeLevel()
    {
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
