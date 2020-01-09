﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndTriggerTwo : MonoBehaviour
{
    public Text levelComplete;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelComplete.gameObject.SetActive(true);
            SceneManager.LoadScene("03_Level_03");
        }
    }
}
