using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public Text PlayerText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f; // Distance between bricks
        int perLine = Mathf.FloorToInt(4.0f / step); // Number of bricks per line

        int[] pointCountArray = new [] {1,1,2,2,5,5}; // Points for each line
        for (int i = 0; i < LineCount; ++i) // Loop through each line
        {
            for (int x = 0; x < perLine; ++x) // Loop through each brick in the line
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0); // Calculate brick position
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity); // Create brick instance
                brick.PointValue = pointCountArray[i]; // Set brick point value
                brick.onDestroyed.AddListener(AddPoint); // Add listener for brick destruction
            }
        }

        //BestScoreText.text = $"Best Score : {MainDataManager.Instance.BestPlayerName} : {MainDataManager.Instance.HighScore}";

        PlayerText.text = $"Player : {MainDataManager.Instance.PlayerName}";



    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Start the game on space key press
            {
                m_Started = true; // Set game as started
                float randomDirection = Random.Range(-1.0f, 1.0f); // Random horizontal direction
                Vector3 forceDir = new Vector3(randomDirection, 1, 0); // Initial force direction
                forceDir.Normalize();   // Normalize the direction vector

                Ball.transform.SetParent(null);     // Detach ball from parent
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange); // Apply force to the ball
            }
        }
        else if (m_GameOver) // If the game is over
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Restart the game on space key press
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point; // Add points to the score
        ScoreText.text = $"Score : {m_Points}"; // Update score text
        MainDataManager.Instance.ActualSessionScore = m_Points; // Update session score
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
