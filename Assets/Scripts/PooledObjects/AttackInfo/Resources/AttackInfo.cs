﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    public CharacterControl Attacker = null;
    public Attack AttackAbility;
    public List<string> ColliderNames = new List<string>();
    public bool MustCollide;
    public bool MustFaceAttacker;
    public float LethalRange;
    public int MaxHits;
    public int CurrentHits;
    public bool isRegistered;
    public bool isFinished;
    
    public void ResetInfo(Attack attack, CharacterControl attacker)
    {
        isRegistered = false;
        isFinished = false;
        AttackAbility = attack;
        Attacker = attacker;
    }

    public void Register(Attack attack)
    {
        isRegistered = true;

        AttackAbility = attack;
        ColliderNames = attack.ColliderNames;
        MustCollide = attack.MustCollide;
        MustFaceAttacker = attack.MustFaceAttacker;
        LethalRange = attack.LethalRange;
        MaxHits = attack.MaxHits;
        CurrentHits = 0;
    }

    private void OnDisable()
    {
        isFinished = true;
    }
}
