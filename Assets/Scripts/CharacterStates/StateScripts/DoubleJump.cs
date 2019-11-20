using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/DoubleJump")]
public class DoubleJump : StateData
{
    public float jumpForce;
    public AnimationCurve Gravity;
    public AnimationCurve Pull;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * jumpForce);
        animator.SetBool("Grounded", false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
        control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

