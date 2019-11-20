﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/GroundDetector")]
public class GroundDetector : StateData
{
    [Range(0.01f, 1f)]
    public float CheckTime;
    public float Distance;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (stateInfo.normalizedTime >= CheckTime)
        {
            if (IsGrounded(control))
            {
                animator.SetBool("Grounded", true);
            }

            else
            {
                animator.SetBool("Grounded", false);
            }
        }

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    bool IsGrounded(CharacterControl control)
    {
        if (control.RIGID_BODY.velocity.y > -0.01f && control.RIGID_BODY.velocity.y <= 0f)
        {
            return true;
        }

        foreach (GameObject o in control.BottomSpheres)
        {
            Debug.DrawRay(o.transform.position, -Vector3.up * 0.7f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, -Vector3.up, out hit, Distance))
            {
                return true;
            }
        }

        return false;
    }
}

