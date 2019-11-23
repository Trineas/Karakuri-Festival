using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Attack")]
public class Attack : StateData
{
    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("Attack", false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.Attack)
        {
            animator.SetBool("Attack", true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

