﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject character1, character2, character3;
    public static int characterSwitch;
    public bool character3Enabled;

    void Start()
    {
        characterSwitch = 1;
    }

    void Update()
    {
        if (VirtualInputManager.Instance.CharacterSwitchRight)
        {

                if (characterSwitch == 1)
                {
                    characterSwitch = 2;
                }

                else if (characterSwitch == 2)
                {
                    if (character3Enabled)
                    {
                        characterSwitch = 3;
                    }

                    else
                    {
                        characterSwitch = 1;
                    }
                }

                else if (characterSwitch == 3)
                {
                    if (character3Enabled)
                    {
                        characterSwitch = 1;
                    }
                }
        }

        if (VirtualInputManager.Instance.CharacterSwitchLeft)
        {

            if (characterSwitch == 1)
            {
                if (character3Enabled)
                {
                    characterSwitch = 3;
                }

                else
                {
                    characterSwitch = 2;
                }
            }

            else if (characterSwitch == 2)
            {
                characterSwitch = 1;
            }

            else if (characterSwitch == 3)
            {
                if (character3Enabled)
                {
                    characterSwitch = 2;
                }
            }
        }

        if (characterSwitch == 1)
        {
            character1.SetActive(true);
            character2.SetActive(false);
            character3.SetActive(false);
        }

        if (characterSwitch == 2)
        {
            character1.SetActive(false);
            character2.SetActive(true);
            character3.SetActive(false);
        }

        if (characterSwitch == 3)
        {
            character1.SetActive(false);
            character2.SetActive(false);
            character3.SetActive(true);
        }
    }
    // particles for later?
    /* if (info.AttackAbility.UseDeathParticles)
                    {
                        if (info.AttackAbility.ParticleType.ToString().Contains("VFX"))
                        {
                            GameObject vfx =
                                PoolManager.Instance.GetObject(info.AttackAbility.ParticleType);

    vfx.transform.position =
                                control.animationProgress.AttackingPart.transform.position;

                            vfx.SetActive(true);

                            if (info.Attacker.IsFacingForward())
                            {
                                vfx.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                            }
                            else
                            {
                                vfx.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                            }
    */
}

