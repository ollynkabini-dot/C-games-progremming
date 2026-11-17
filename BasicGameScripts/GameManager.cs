using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public int winScore = 100;

    public TMP_Text finalScoreText;
    public TMP_Text scoreText;
    public TMP_Text livesText;

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;

        score = 0;
        lives = 3;
        gameEnded = false;

        if (startPanel != null)
            startPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);

        UpdateUI();
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        UpdateUI();

        if (score >= winScore)
        {
            WinGame();
        }
    }

public void LoseLife()
{
    if (gameEnded) return;

    lives = Mathf.Max(0, lives - 1);

    Debug.Log("Hazard hit! Lives remaining: " + lives);

    UpdateUI();

    if (lives <= 0)
    {
        GameOver();
    }
}

void GameOver()
{
    gameEnded = true;

    Debug.Log("GAME OVER! Final score: " + score);

    if (gameOverPanel != null)
    {
        gameOverPanel.SetActive(true);
    }
    else
    {
        Debug.LogError("Game Over Panel is not assigned in GameManager!");
    }

    if (finalScoreText != null)
    {
        finalScoreText.text = "Final Score: " + score;
    }

    Time.timeScale = 0f;
}

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    /*
    void GameOver()
    {
        gameEnded = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + score;

        Time.timeScale = 0f;
    } */

    void WinGame()
    {
        gameEnded = true;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}