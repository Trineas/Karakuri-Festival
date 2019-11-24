using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    GameObject character1, character2;
    int characterSwitch;

    void Start()
    {
        characterSwitch = 1;
        character1 = GameObject.Find("Taku");
        character2 = GameObject.Find("Baku");
    }

    private IEnumerator SwitchDelay()
    {
        yield return new WaitForSeconds(5f);
    }

    void Update()
    {
        if (Input.GetButtonDown("CharacterSwitch"))
        {
            if (characterSwitch == 1)
            {
                characterSwitch = 2;
            }
 
            else if (characterSwitch == 2)
            {
                characterSwitch = 1;
            }
         }

        if (characterSwitch == 1)
        {
            SwitchDelay();
            character1.SetActive(true);
            character2.SetActive(false);
        }

        if (characterSwitch == 2)
        {
            SwitchDelay();
            character1.SetActive(false);
            character2.SetActive(true);
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

