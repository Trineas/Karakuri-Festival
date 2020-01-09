using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndTriggerThree : MonoBehaviour
{
    public Image levelComplete;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelComplete.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
