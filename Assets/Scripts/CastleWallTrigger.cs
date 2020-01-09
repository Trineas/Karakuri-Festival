using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleWallTrigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
