using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public GameObject yboundary;
    public GameObject player;
    public Image gameOver;

    public OverlayScreens overlayScreens;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("01_Level_01");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (player.transform.position.y < yboundary.transform.position.y)
        {
            overlayScreens.gameoverActive = true;
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
