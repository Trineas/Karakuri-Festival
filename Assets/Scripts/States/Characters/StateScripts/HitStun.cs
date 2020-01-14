using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/HitStun")]
public class HitStun : StateData
{
    public float pushBack;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {      
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.IsFacingForward())
        {
            characterState.GetCharacterControl(animator).RIGID_BODY.velocity = Vector3.zero;
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.left * pushBack);
        }

        else
        {
            characterState.GetCharacterControl(animator).RIGID_BODY.velocity = Vector3.zero;
            characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.right * pushBack);
        }

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("Hit", false);
    }
}

