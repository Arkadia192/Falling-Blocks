using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject movementButtons;
    public GameObject gameUi;
    public Text secondsSurvivedUI;
    public Text scoreUI;

    bool gameOver;

    bool buttonPress = false;

	// Use this for initialization
	void Start () {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ScoreSystem.Reset();
                SceneManager.LoadScene(1);
            }
            if (buttonPress)
            {
                buttonPress = false;
                ScoreSystem.Reset();
                SceneManager.LoadScene(1);
            }
        }
	}

    public void pressButton()
    {
        buttonPress = true;
    }

    void OnGameOver()
    {
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        scoreUI.text = Mathf.RoundToInt(ScoreSystem.GetScore()).ToString();
        gameOverScreen.SetActive (true);
        movementButtons.SetActive(false);
        gameUi.SetActive(false);
        gameOver = true;
    }
}
