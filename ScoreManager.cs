using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;
    public Text speedText;

    public int score = 0;
    public int highscore = 0;
    public int speed = 1;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        // scoreText.text = "SCORE: " + score;
        // highscoreText.text = "HIGHSCORE: " + highscore;
        // speedText.text = "SPEED: " + speed;
        scoreText.text = "" + score;
        highscoreText.text = "" + highscore;
        speedText.text = "" + speed;
    }

    public void AddScore()
    {
        score += 100;
        // scoreText.text = "SCORE: " + score.ToString();
        scoreText.text = "" + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }

    public void ResetHighscore()
    {
        highscore = 0;
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void SpeedUp()
    {
        speed += 1;
        // speedText.text = "SPEED: " + speed.ToString();
        speedText.text = "" + speed.ToString();
    }
}
