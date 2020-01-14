using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayScreens : MonoBehaviour
{
    public Image title;
    public Image pauseScreen;
    public Image gameOver;

    public bool titleActive;
    public bool pauseActive;
    public bool gameoverActive;

    public GameObject player;

    void Start()
    {
        pauseActive = false;
        gameoverActive = false;

        if (titleActive)
        {
            title.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (titleActive)
            {
                titleActive = false;
                title.gameObject.SetActive(false);
                Time.timeScale = 1;
            }

            else if (!titleActive && !gameoverActive)
            {
                if (!pauseActive)
                {
                    pauseActive = true;
                    pauseScreen.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }

                else if (pauseActive)
                {
                    pauseActive = false;
                    pauseScreen.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }

        // game over screen on x damage taken
        DamageDetector dd = player.gameObject.transform.root.GetComponent<DamageDetector>();

        if (dd.DamageTaken >= 3)
        {
            gameoverActive = true;
            gameOver.gameObject.SetActive(true);
        }
    }
}
