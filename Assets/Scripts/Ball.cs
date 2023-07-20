using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] MoveRacket leftRacket;
    [SerializeField] MoveRacket rightRacket;

    public int Speed
    {
        get { return speed; }
    }

    public IEnumerator SpeedUp()
    {
        if (speed <= 100)
        {
            speed += 5;
        }
        yield return null;
    }

    private float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft")
        {
            float hitFactor = HitFactor(this.transform.position, collision.transform.position, 
                                        collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, hitFactor).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            float hitFactor = HitFactor(this.transform.position, collision.transform.position,
                                        collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, hitFactor).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Left player score
        if (collision.gameObject.name == "WallRight")
        {
            leftRacket.Scoring();
            leftRacket.UpdateScore();
        }

        // Right player score
        if (collision.gameObject.name == "WallLeft")
        {
            rightRacket.Scoring();
            rightRacket.UpdateScore();
        }    
    }

    public void GameOver()
    {
        this.gameObject.SetActive(false);
    }
}
