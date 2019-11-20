using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/MoveForward")]
public class MoveForward : StateData
{
    public AnimationCurve SpeedGraph;
    public float runSpeed;
    public float BlockDistance;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (control.Jump)
        {
            animator.SetBool("Jump", true);
        }

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
            control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (!CheckFront(control))
            {
                control.transform.Translate(Vector3.right * runSpeed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }
        }

        if (control.MoveLeft)
        {
            control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            if (!CheckFront(control))
            {
                control.transform.Translate(Vector3.right * runSpeed * SpeedGraph.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    bool CheckFront(CharacterControl control)
    {
        foreach (GameObject o in control.FrontSpheres)
        {
            Debug.DrawRay(o.transform.position, control.transform.right * 0.3f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, control.transform.right, out hit, BlockDistance))
            {
                return true;
            }
        }

        return false;
    }
}
