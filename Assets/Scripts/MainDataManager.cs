using UnityEngine;

public class MainDataManager : MonoBehaviour
{

    public static MainDataManager Instance; // Singleton instance

    public int HighScore; // Variable to store high score
    public int LowScore; // Variable to store low score
    public int MaxScore; // Variable to store max score
    public int ActualSessionScore; // Variable to store session score
    public string PlayerName; // Variable to store player name
    public string BestPlayerName; // Variable to store best player name


    private void Awake() // Awake is called when the script instance is being loaded
    {
        if (Instance != null) // Check if an instance already exists
        {
            Destroy(gameObject); // Destroy this object to enforce singleton pattern
            return;
        }

        Instance = this; // Assign the singleton instance
        DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
    }



}
