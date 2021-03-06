﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockChar : MonoBehaviour
{
    public GameObject player;
    public GameObject yaeObject;
    public Text unlockText;

    void Start()
    {
        unlockText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        CharacterSwitch cw = player.gameObject.transform.root.GetComponent<CharacterSwitch>();

        if (other.tag == "Player")
        {
            unlockText.gameObject.SetActive(true);
            cw.character3Enabled = true;
            Destroy(yaeObject.gameObject);
            Destroy(this.gameObject, 5f);
        }
    }
}
