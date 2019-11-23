using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/MoveForward")]
public class MoveForward : StateData
{
    public AnimationCurve SpeedGraph;
    public float Speed;
    public float BlockDistance;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        animator.SetBool("Attack", false);
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
            control.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (!CheckFront(control))
            {
                control.MoveForward(Speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
            }
        }

        if (control.MoveLeft)
        {
            control.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            if (!CheckFront(control))
            {
                control.MoveForward(Speed, SpeedGraph.Evaluate(stateInfo.normalizedTime));
            }
        }

        if (control.Attack)
        {
            animator.SetBool("Attack", true);
        }

        if (control.Jump)
        {
            animator.SetBool("Jump", true);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        
    }

    // front checker
    bool CheckFront(CharacterControl control)
    {
        foreach (GameObject o in control.FrontSpheres)
        {
            Debug.DrawRay(o.transform.position, control.transform.right * 0.3f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(o.transform.position, control.transform.right, out hit, BlockDistance))
            {
                if (!control.RagdollParts.Contains(hit.collider))
                {
                    if (IsBodyPart(hit.collider))
                    {
                        return true;
                    }
    
                }
            }

        }

        return false;
    }

    bool IsBodyPart(Collider col)
    {
        CharacterControl control = col.transform.root.GetComponent<CharacterControl>();

        if (control == null)
        {
            return false;
        }

        if (control.gameObject == col.gameObject)
        {
            return false;
        }

        if (control.RagdollParts.Contains(col))
        {
            return true;
        }

        return false;
    }
}
