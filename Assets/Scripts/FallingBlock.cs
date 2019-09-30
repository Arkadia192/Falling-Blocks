using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

    public Vector2 speedMinMax = new Vector2(7f, 13f);
    public float speed;

    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
    }

    void Update () {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        
        if (transform.position.y < -Camera.main.orthographicSize - transform.localScale.y)
        {
            ScoreSystem.AddScore(ScoreSystem.ppBlockMultiplier * Difficulty.GetDifficultyPercent() * 100);
            Destroy(gameObject);
        }
	}
}
