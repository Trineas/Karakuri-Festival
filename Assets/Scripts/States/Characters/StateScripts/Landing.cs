﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Landing")]
public class Landing : StateData
{

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool(TransitionParameter.Jump.ToString(), false);
        animator.SetBool(TransitionParameter.DoubleJump.ToString(), false);
        // disable?
        //animator.SetBool("Move", false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

