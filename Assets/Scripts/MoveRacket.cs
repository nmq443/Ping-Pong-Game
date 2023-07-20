using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRacket : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] string axis;
    [SerializeField] Text scoreText;
    [SerializeField] Ball ball;
    [SerializeField] Text winnerText;
    [SerializeField] GameObject gameOverPanel;

    float time = 0;
    float interpolationPeriod = 10f;

    int score;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis);
        // winnerText.text = "";
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;

        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            time -= interpolationPeriod;
            StartCoroutine(ball.SpeedUp());
            Debug.Log(ball.Speed);
            Debug.Log("ball speeded up");
        }

        scoreText.gameObject.SetActive(true);
        if (GameOver())
        {
            this.enabled = false;
        }
    }

    public void UpdateScore()
    {
        if (score > 0)
        {
            scoreText.text = score.ToString();
            Debug.Log($"{this.name}'s score is {scoreText.text}");
        }
    }

    public int Score
    {
        get { return score; }
    }

    public void Scoring()
    {
        score++;
    }

    public bool GameOver()
    {
        if (score == 3)
        {
            Debug.Log($"{this.name} won!");
            winnerText.text = $"{this.name} won!";
            ball.GameOver();
            gameOverPanel.SetActive(true);
            return true;
        }
        return false;
    }
}
