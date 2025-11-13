using UnityEngine;
using System.IO;    

public class MainDataManager : MonoBehaviour
{

    public static MainDataManager Instance; // Singleton instance
    public GameObject BestPlayerText;
    public GameObject BestScore;

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

        LoadScore(); // Load the score data when the game starts
        Debug.Log("Awakw Load Score ausgeführt");
        //BestScore.GetComponent<UnityEngine.UI.Text>().text = "Best Player: " + MainDataManager.Instance.BestPlayerName + " - Score: " + MainDataManager.Instance.HighScore;

    }

    [System.Serializable] // Make the class serializable for JSON conversion
    class SaveScoreData // Class to hold score data for saving
    {
        public int HighScore; // Variable to store high score
        public string BestPlayerName; // Variable to store best player name
    }

    public void SaveScore() 
    {
        SaveScoreData data = new SaveScoreData(); // Create a new instance of SaveScoreData
        data.HighScore = HighScore; // Assign the high score to the data object
        data.BestPlayerName = BestPlayerName; // Assign the best player name to the data object
        string json = JsonUtility.ToJson(data); // Convert the data object to JSON format
        File.WriteAllText(Application.persistentDataPath + "/scoredata.json", json); // Write the JSON data to a file
        Debug.Log(Application.persistentDataPath);

    }


    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/scoredata.json"; // Define the file path for the score data
        
        if (File.Exists(path)) // Check if the score data file exists
        {
            string json = File.ReadAllText(path); // Read the JSON data from the file
            SaveScoreData data = JsonUtility.FromJson<SaveScoreData>(json); // Convert the JSON data back to a SaveScoreData object
            HighScore = data.HighScore; // Assign the loaded high score to the variable
            BestPlayerName = data.BestPlayerName; // Assign the loaded best player name to the variable
        }

    }


}
