using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraTrigger
    {
        Default,
        Shake,
    }

    private Animator animator;
    public Animator ANIMATOR
    {
        get
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }

            return animator;
        }
    }

    public void TriggerCamera(CameraTrigger trigger)
    {
        ANIMATOR.SetTrigger(trigger.ToString());
    }
}
