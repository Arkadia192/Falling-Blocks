﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControlls : MonoBehaviour {

    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
    }
}
