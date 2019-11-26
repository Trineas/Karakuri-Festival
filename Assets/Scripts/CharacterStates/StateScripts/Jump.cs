using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Jump")]
public class Jump : StateData
{
    public float jumpForce;
    public float StartJumpTime;
    public float EndJumpTime;
    public AnimationCurve Gravity;
    public AnimationCurve Pull;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        characterState.GetCharacterControl(animator).RIGID_BODY.AddForce(Vector3.up * jumpForce);
        animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        animator.SetBool(TransitionParameter.Attack.ToString(), false);
        animator.SetBool(TransitionParameter.DoubleJump.ToString(), false);
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
        control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        CheckDoubleJump(characterState, animator, stateInfo);

        if (control.Attack)
        {
            animator.SetBool(TransitionParameter.Attack.ToString(), true);
        }
    }

    public void CheckDoubleJump(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (stateInfo.normalizedTime >= StartJumpTime + ((EndJumpTime - StartJumpTime) / 3f))
        {
            if (stateInfo.normalizedTime < EndJumpTime + ((EndJumpTime - StartJumpTime) / 2f))
            {
                CharacterControl control = characterState.GetCharacterControl(animator);
                if (control.Jump)
                {
                    animator.SetBool(TransitionParameter.DoubleJump.ToString(), true);
                }
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }
}

