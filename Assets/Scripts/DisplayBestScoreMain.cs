// 13.11.2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using TMPro;

public class DisplayBestScoreMain : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        UpdateBestScore();
    }

    public void UpdateBestScore()
    {
        // Assuming MainDataManager.Instance contains the HighScore and BestPlayerName variables
        int highScore = MainDataManager.Instance.HighScore;
        string bestPlayerName = MainDataManager.Instance.BestPlayerName;

        // Update the BestScore text field
        if (bestScoreText != null)
        {
            bestScoreText.text = $"Best Player: {bestPlayerName} - Score: {highScore}";
        }
        else
        {
            Debug.LogError("BestScore TextMeshProUGUI component is not assigned!");
        }
    }
}
