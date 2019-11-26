using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject Spawnpoint;
    private float bottomBound = -5;

    void Update()
    {
        if (transform.position.y < bottomBound)
        {
            transform.position = Spawnpoint.transform.position;
        }
    }
}
