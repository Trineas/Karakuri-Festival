﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/ShakeCamera")]
public class ShakeCamera : StateData
{
    [Range(0f, 0.99f)]
    public float ShakeTiming;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        if (ShakeTiming == 0f)
        {
            CharacterControl control = characterState.GetCharacterControl(animator);
            CameraManager.Instance.ShakeCamera(0.2f);
            control.animationProgress.CameraShaken = true;
        }
    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (!control.animationProgress.CameraShaken)
        {
            if (stateInfo.normalizedTime >= ShakeTiming)
            {
                control.animationProgress.CameraShaken = true;
                CameraManager.Instance.ShakeCamera(0.2f);
            }
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        control.animationProgress.CameraShaken = false;
    }
}