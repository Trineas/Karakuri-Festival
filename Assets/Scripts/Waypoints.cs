using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public CharacterControl control;

    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float WPRadius = 1;

    void Update()
    {
        control = GetComponent<CharacterControl>();

        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPRadius)
        {
            current++;

            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        transform.rotation = waypoints[current].transform.rotation;

        if (control.SkinnedMeshAnimator1.GetBool("Death") == true)
        {
            speed = 0;
        }
    }
}
