using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public event Action<int> OnScoreChanged;
    public event Action OnPlayerDied;

    [SerializeField] private int playerLives = 3;
    public int Lives { get { return playerLives; } }

    private int currentScore = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void IncreaseScore(int amount)
    {
        currentScore += amount;
        OnScoreChanged?.Invoke(currentScore);
    }

    public void LoseLife()
    {
        playerLives--;

        if (playerLives <= 0)
        {
            OnPlayerDied?.Invoke();
        }
    }
}