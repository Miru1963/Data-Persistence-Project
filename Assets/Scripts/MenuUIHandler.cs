using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;





// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]



public class MenuUIHandler : MonoBehaviour
{
    public GameObject RememberNameText;
    public GameObject BestPlayerText;
    private new string name = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        BestPlayerText.GetComponent<UnityEngine.UI.Text>().text = "Best Player: " + MainDataManager.Instance.BestPlayerName + " - Score: " + MainDataManager.Instance.HighScore;
    }

    public void OnStartButtonPressed() // Called when the Start button is pressed
    {
       
        Debug.Log("Start Button Pressed"); // Add logic to start the game
        name = MainDataManager.Instance.PlayerName; // Retrieve the player name from MainDataManager

        if (!string.IsNullOrEmpty(name) && name != "Your name?") // Check if the player name is set
        {
            // Player name is already set, proceed to start the game
            RememberNameText.SetActive(false); // Hide the remember name text if it was shown previously
            SceneManager.LoadScene(1); // Assuming the main game scene is at index 1
            return;
        }
        else
        {              
            
            Debug.Log("Player Name fehlt"); // Log that the player name is missing
            RememberNameText.SetActive(true); // Show the remember name text
            WaitForSecondsRealtime wait = new WaitForSecondsRealtime(10f); ; // Wait for 10 seconds               
            if (!string.IsNullOrEmpty(name) && name != "Your name?") 
            {
                SceneManager.LoadScene(0); // Reload the menu scene to allow the player to enter their name

            }
        }

    }

    public void OnExitButtonPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

        MainDataManager.Instance.SaveScore(); // Save the score data before exiting


    }

    public void OnBacktoMenuButtonPressed()
    {
        Debug.Log("Back to Menu Button Pressed");
        // Add logic to open options menu
        SceneManager.LoadScene(0); // Assuming the main menu scene is at index 0

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
