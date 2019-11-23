using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    GameObject character1, character2;
    int characterSwitch;

    void Start()
    {
        characterSwitch = 1;
        character1 = GameObject.Find("Taku");
        character2 = GameObject.Find("Baku");
    }

    private IEnumerator SwitchDelay()
    {
        yield return new WaitForSeconds(5f);
    }

    void Update()
    {
        if (Input.GetButtonDown("CharacterSwitch"))
        {
            if (characterSwitch == 1)
            {
                characterSwitch = 2;
            }
 
            else if (characterSwitch == 2)
            {
                characterSwitch = 1;
            }
         }

        if (characterSwitch == 1)
        {
            SwitchDelay();
            character1.SetActive(true);
            character2.SetActive(false);
        }

        if (characterSwitch == 2)
        {
            SwitchDelay();
            character1.SetActive(false);
            character2.SetActive(true);
        }
    }
}
