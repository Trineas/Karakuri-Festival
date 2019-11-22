using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
public class PlayerFollower : MonoBehaviour 
{
  
private Transform target;
  
     void Start() 
     {
        target = GameObject.Find("Player").transform;
     }
  
     void Update() 
     {
        if (target.position.y == 8)
        {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        }

        else if (target.position.y == 4)
        {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        }

        else if ((target.position.y <= 0) && (target.position.y >= -3))
        {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
        }

        else
        {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        }
     }
 }