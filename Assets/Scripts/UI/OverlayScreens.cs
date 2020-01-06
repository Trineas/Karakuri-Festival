using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayScreens : MonoBehaviour
{
    public Image title;
    public Image pauseScreen;
    //public Image characterScreen;
    public Image gameOver;
    //public Image hud;

    public bool titleActive;
    public bool pauseActive;
    //public bool charscreenActive;

    public GameObject player;

    void Start()
    {
        titleActive = true;
        pauseActive = false;
        //charscreenActive = false;
        //hud.gameObject.SetActive(false);
        title.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // title screen
        if (titleActive)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                titleActive = false;
                title.gameObject.SetActive(false);
                //hud.gameObject.SetActive(true);
                Time.timeScale = 1;
            }
        }

        // pause screen
        if (!titleActive)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                //charscreenActive = false;
                //characterScreen.gameObject.SetActive(false);

                pauseActive = true;
                pauseScreen.gameObject.SetActive(true);

                Time.timeScale = 0;
            }

            if (pauseActive)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7))
                {
                    pauseActive = false;
                    pauseScreen.gameObject.SetActive(false);

                    Time.timeScale = 1;
                }

                if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button6))
                {
                    //charscreenActive = true;
                    //characterScreen.gameObject.SetActive(true);

                    Time.timeScale = 0;
                }
            }

            // character screen
            /*if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                pauseActive = false;
                pauseScreen.gameObject.SetActive(false);

                charscreenActive = true;
                characterScreen.gameObject.SetActive(true);

                Time.timeScale = 0;
            }

            if (charscreenActive)
            {
                if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button6))
                {
                    charscreenActive = false;
                    characterScreen.gameObject.SetActive(false);

                    Time.timeScale = 1;
                }

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7))
                {
                    pauseActive = true;
                    pauseScreen.gameObject.SetActive(true);

                    Time.timeScale = 0;
                }
            }*/
        }

        // game over screen on enough damage taken
        DamageDetector dd = player.gameObject.transform.root.GetComponent<DamageDetector>();

        if (dd.DamageTaken >= 3)
        {
            gameOver.gameObject.SetActive(true);
        }
    }
}
