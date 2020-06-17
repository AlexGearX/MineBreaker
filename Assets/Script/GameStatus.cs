using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int PointPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // State Variables
    [SerializeField] int currentScore = 0;

    public void resetScore()
    {
        currentScore = 0;
        Destroy(gameObject);
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        countScore();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }

    public void addToScore()
    {
        currentScore += PointPerBlockDestroyed;
        countScore();
    }

    private void countScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
