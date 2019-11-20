using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Idle")]
public class Idle : StateData
{

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        // disable?
        animator.SetBool("Jump", false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.MoveRight)
        {
            animator.SetBool("Move", true);
        }

        if (control.MoveLeft)
        {
            animator.SetBool("Move", true);
        }

        if (control.Jump)
        {
            animator.SetBool("Jump", true);
        }

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}

