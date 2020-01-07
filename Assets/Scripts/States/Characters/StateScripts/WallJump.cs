﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/WallJump")]
public class WallJump : StateData
{

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        characterState.characterControl.RIGID_BODY.velocity = Vector3.zero;

        if (characterState.characterControl.IsFacingForward())
        {
            characterState.characterControl.FaceForward(false);
        }

        else
        {
            characterState.characterControl.FaceForward(true);
        }
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(TransitionParameter.WallJump.ToString(), false);
    }
}

