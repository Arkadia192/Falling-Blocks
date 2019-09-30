using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 7f;

    public event System.Action OnPlayerDeath;

    float screenHalfWidth;

    float movementVector = 0;

	
	void Start () {

        float halfPlayerWidth = 0.5f; // transform.localScale.x / 2f;
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
	}

	void Update () {

        //float inputX = Input.GetAxisRaw("Horizontal");
        float inputX = movementVector + Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }

        if (transform.position.x > screenHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Killer")
        {
            print("You have been deathed");
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }

        if (collision.tag == "Cookie")
        {
            print("You got a cookie!");
            ScoreSystem.AddScore(ScoreSystem.ppCookieMultiplier * Difficulty.GetDifficultyPercent() * 100);
            Destroy(collision.gameObject);
        }
    }

    public void goRight()
    {
        movementVector += 1;
    }

    public void goLeft()
    {
        movementVector -= 1;
    }
}
