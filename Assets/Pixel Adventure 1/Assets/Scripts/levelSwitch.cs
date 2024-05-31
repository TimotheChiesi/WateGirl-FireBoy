using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    private string nextLevelName;
    private int currentLevel;

    // Recuperer le num du level
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
            return 0; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterGirl") && gameObject.CompareTag("WaterGirlDoor"))
        {
            Debug.Log("WaterGirl entered her door...");
            StateManager.WaterGirlInDoor = true;
            CheckAndChangeLevel();
        }
        else if (collision.CompareTag("FireBoy") && gameObject.CompareTag("FireBoyDoor"))
        {
            Debug.Log("FireBoy entered his door...");
            StateManager.FireBoyInDoor = true;
            CheckAndChangeLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterGirl") && gameObject.CompareTag("WaterGirlDoor"))
        {
            Debug.Log("WaterGirl left her door area...");
            StateManager.WaterGirlInDoor = false;
        }
        else if (collision.CompareTag("FireBoy") && gameObject.CompareTag("FireBoyDoor"))
        {
            Debug.Log("FireBoy left his door area...");
            StateManager.FireBoyInDoor = false;
        }
    }

    void Start()
    {
        // Recuperer le num du level
        currentLevel = GetLevelNumberFromSceneName(SceneManager.GetActiveScene().name);
        Debug.Log($"Current level: {currentLevel}");
    }

    private void CheckAndChangeLevel()
    {
        Debug.Log("Check And Change Level...");
        Debug.Log($"FireBoyInDoor: {StateManager.FireBoyInDoor}");
        Debug.Log($"WaterGirlInDoor: {StateManager.WaterGirlInDoor}");
        if (StateManager.WaterGirlInDoor && StateManager.FireBoyInDoor)
        {
            Debug.Log("Both characters are in their doors, changing level...");
            ChangeLevel();
        }
    }

    private void ChangeLevel()
    {
        if (currentLevel == 0)
        {
            nextLevelName = "Level_1";
        }
        else
        {
            nextLevelName = "Level_" + (currentLevel + 1).ToString();
        }

        if (string.IsNullOrEmpty(nextLevelName))
        {
            Debug.LogError("Next level name is empty or null!");
            return;
        }

        Debug.Log("Loading level: " + nextLevelName);
        if (Application.CanStreamedLevelBeLoaded(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
            StateManager.ResetState(); // Reset state after loading new level
        }
        else
        {
            Debug.LogError("Level " + nextLevelName + " cannot be loaded. Make sure it is added to the Build Settings.");
        }
    }
}
