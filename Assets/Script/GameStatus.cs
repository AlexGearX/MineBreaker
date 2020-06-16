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

    // Start is called before the first frame update
    void Start()
    {
        countScore();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        countScore();
    }

    public void addToScore()
    {
        currentScore += PointPerBlockDestroyed;
    }

    private void countScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
