using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/Idle")]
public class Idle : StateData
{

    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        if (VirtualInputManager.Instance.MoveRight)
        {
            animator.SetBool("Move", true);
        }

        if (VirtualInputManager.Instance.MoveLeft)
        {
            animator.SetBool("Move", true);
        }

    }
}

