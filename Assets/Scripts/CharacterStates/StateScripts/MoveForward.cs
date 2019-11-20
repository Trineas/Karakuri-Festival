using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/MoveForward")]
public class MoveForward : StateData
{
    public float runSpeed;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.MoveRight && control.MoveLeft)
        {
            animator.SetBool("Move", false);
            return;
        }

        if (!control.MoveRight && !control.MoveLeft)
        {
            animator.SetBool("Move", false);
            return;
        }

        if (control.MoveRight)
        {
            control.transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (control.MoveLeft)
        {
            control.transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }
}
