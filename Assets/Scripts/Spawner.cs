using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject fallingBlock;
    public GameObject cookie;

    public Vector2 betweenSpawnsMinMax = new Vector2(0.3f, 1f);
    float nextSpawnTime;

    public Vector2 cookieBetweenSpawnsMinMax = new Vector2(1.5f, 5f);
    float cookieNextSpawnTime;

    public Vector2 spawnSizeMinMax = new Vector2(0.3f, 2f);
    public float spawnAngleMax = 15f;

    Vector2 screenHalfSize;

	// Use this for initialization
	void Start () {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawnTime)
        {
            float spawnAngle;
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);

            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);
            if (spawnPosition.x < 0) { spawnAngle = Random.Range(0, spawnAngleMax); }
            else { spawnAngle = Random.Range(-spawnAngleMax, 0); }

            GameObject newBlock = (GameObject) Instantiate(fallingBlock, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            newBlock.transform.localScale = Vector2.one * spawnSize;
            nextSpawnTime = Time.time + Mathf.Lerp(betweenSpawnsMinMax.y, betweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
        }

        if (Time.time > cookieNextSpawnTime)
        {
            float spawnAngle;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y);

            if (spawnPosition.x < 0) { spawnAngle = Random.Range(0, spawnAngleMax); }
            else { spawnAngle = Random.Range(-spawnAngleMax, 0); }

            Instantiate(cookie, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

            cookieNextSpawnTime = Time.time + Mathf.Lerp(cookieBetweenSpawnsMinMax.y, cookieBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
        }
	}
}
