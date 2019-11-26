using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Spawnpoint;
    private float bottomBound = -5;

    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            transform.position = Spawnpoint.transform.position;
        }

        else if (transform.position.y < bottomBound)
        {
            transform.position = Spawnpoint.transform.position;
        }
    }
}
