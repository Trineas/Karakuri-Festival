using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "KarakuriFestival/AbilityData/SpawnProjectiles")]
public class SpawnProjectiles : StateData
{
    public PoolObjectType ObjectType;
    [Range(0f, 1f)]
    public float SpawnTiming;
    public string SpawnPosition;
    public int Amount;
    public float Interval;

    public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {

    }

    public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);

        if (stateInfo.normalizedTime > SpawnTiming)
        {
            control.animationProgress.SpawnProjectiles(this);
        }
    }

    public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
    {
        CharacterControl control = characterState.GetCharacterControl(animator);
        control.animationProgress.SpawnProjectilesRoutine = null;
    }
}