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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnStartButtonPressed()
    {
        Debug.Log("Start Button Pressed");
        // Add logic to start the game
        SceneManager.LoadScene(1); // Assuming the main game scene is at index 1

    }

    public void OnExitButtonPressed()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
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
