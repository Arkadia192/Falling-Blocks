using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControls : MonoBehaviour {

    public Text ScoreCounter;
    public Text TimeSurvived;


	void FixedUpdate () {

        ScoreCounter.text = "Score: " + Mathf.RoundToInt(ScoreSystem.GetScore());

        TimeSurvived.text = "Time Survived: " + Mathf.RoundToInt(Time.timeSinceLevelLoad);

    }
}
