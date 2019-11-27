﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationProgress : MonoBehaviour
{
    public bool Jumped;
    public bool CameraShaken = false;
    public List<PoolObjectType> PoolObjectList = new List<PoolObjectType>();
    public bool JumpTriggered;
    public float MaxPressTime;

    private CharacterControl control;
    private float PressTime;

    public void Awake()
    {
        control = GetComponentInParent<CharacterControl>();
        PressTime = 0f;
    }

    private void Update()
    {
        if (control.Jump)
        {
            PressTime += Time.deltaTime;
        }

        else
        {
            PressTime = 0f;
        }

        if (PressTime == 0f)
        {
            JumpTriggered = false;
        }

        else if (PressTime > MaxPressTime)
        {
            JumpTriggered = false;
        }

        else
        {
            JumpTriggered = true;
        }
    }
}
