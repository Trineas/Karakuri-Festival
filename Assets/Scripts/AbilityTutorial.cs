using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTutorial : MonoBehaviour
{
    public GameObject player;
    public GameObject tutorial;
    public Text abilityTut;

    void Start()
    {
        abilityTut.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            abilityTut.gameObject.SetActive(true);
            Destroy(this.gameObject, 5f);
        }
    }
}
