using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private TextMeshProUGUI livesText; 
    [SerializeField] private GameObject gameOverPanel; 

    private void Start()
    {
  
        GameManager.Instance.OnScoreChanged += UpdateScoreDisplay;
        GameManager.Instance.OnPlayerDied += ShowGameOver;

        UpdateLivesDisplay(GameManager.Instance.Lives);
        UpdateScoreDisplay(0);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    private void OnDestroy()
    {

        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= UpdateScoreDisplay;
            GameManager.Instance.OnPlayerDied -= ShowGameOver;
        }
    }

    private void UpdateScoreDisplay(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore.ToString();
        }
    }

    private void UpdateLivesDisplay(int currentLives)
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives.ToString();
        }
    }

    private void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}