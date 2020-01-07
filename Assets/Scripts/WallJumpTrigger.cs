using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpTrigger : MonoBehaviour
{
    public bool nearWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Geometry")
        {
            nearWall = true;
        } 

        else
        {
            nearWall = false;
        }
    }
}
