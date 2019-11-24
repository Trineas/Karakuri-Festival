using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObject", menuName = "KarakuriFestival/Death/DeathAnimationData")]
public class DeathAnimationData : ScriptableObject
{
    public List<DeathAnimation> DeathAnimations = new List<DeathAnimation>();
    public RuntimeAnimatorController Animator;
}
