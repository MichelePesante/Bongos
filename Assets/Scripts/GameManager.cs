using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        Score += value;
        UIManager.Instance.UpdateScoreText(Score);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", Score);
    }
}
