using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
        }
    }
}
