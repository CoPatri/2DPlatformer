using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Lives { get;private set; }

    private int coins;
    private int currentLevelIndex;

    public event Action<int> OnLivesChanged;
    public event Action<int> OnCoinsChanged;

    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            RestartGame();
        }
        
    }

    public void KillPlayer()
    {
        Lives--;
        if(OnLivesChanged != null)
        {
            OnLivesChanged(Lives);
        }

        if(Lives <= 0)
        {
            RestartGame();
        }

        else
        {
            SendPlayerToCheckPoint();
        }
    }

    private void SendPlayerToCheckPoint()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();

        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();

        var player = FindObjectOfType<PlayerMovementController>();

        player.transform.position = checkpoint.transform.position;
    }

    internal void AddCoin()
    {
        coins++;
        if(OnCoinsChanged != null)
        {
            OnCoinsChanged(coins);
        }
    }

    public void MoveToNextLevel()
    {
        ++currentLevelIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }

    private void RestartGame()
    {
        currentLevelIndex = 0;
        Lives = 3;
        coins = 0;

        if (OnCoinsChanged != null)
        {
            OnCoinsChanged(coins);
        }
        SceneManager.LoadScene(0);
    }
}
