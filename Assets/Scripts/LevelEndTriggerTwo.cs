using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndTriggerTwo : MonoBehaviour
{
    public Text levelComplete;
    public float delay = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelComplete.gameObject.SetActive(true);
            StartCoroutine(LoadLevelAfterDelay(delay));
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("03_Level_03"); ;
    }
}
