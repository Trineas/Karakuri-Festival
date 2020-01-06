using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text lives;
    public Text health;

    public int hpHud;

    public Image char1;
    public Image char2;
    public Image char3;

   //public Image hud;

    public GameObject player;

    void Update()
    {
        DamageDetector dd = player.gameObject.transform.root.GetComponent<DamageDetector>();
        CharacterSwitch cw = player.gameObject.transform.root.GetComponent<CharacterSwitch>();

        health.text = "Health: " + hpHud;
        lives.text = "Lives: 1";

        if (dd.DamageTaken == 0)
        {
            hpHud = 3;
        }

        if (dd.DamageTaken == 1)
        {
            hpHud = 2;
        }

        if (dd.DamageTaken == 2)
        {
            hpHud = 1;
        }

        if (dd.DamageTaken == 3)
        {
            hpHud = 0;
            lives.text = "Lives: 0";
        }

        if (cw.characterSwitch == 1)
        {
            char1.gameObject.SetActive(true);
            char2.gameObject.SetActive(false);
            char3.gameObject.SetActive(false);
        }

        if (cw.characterSwitch == 2)
        {
            char1.gameObject.SetActive(false);
            char2.gameObject.SetActive(true);
            char3.gameObject.SetActive(false);
        }

        if (cw.characterSwitch == 3)
        {
            char1.gameObject.SetActive(false);
            char2.gameObject.SetActive(false);
            char3.gameObject.SetActive(true);
        }
    }
}

