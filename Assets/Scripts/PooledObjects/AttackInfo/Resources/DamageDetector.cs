using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    CharacterControl control;
    DeathAnimation PickDeathAnimation;

    private void Awake()
    {
        control = GetComponent<CharacterControl>();
    }

    private void Update()
    {
        if (AttackManager.Instance.CurrentAttacks.Count > 0)
        {
            CheckAttack();
        }
    }

    private void CheckAttack()
    {
        foreach(AttackInfo info in AttackManager.Instance.CurrentAttacks)
        {
            if (info == null)
            {
                continue;
            }

            if (!info.isRegistered)
            {
                continue;
            }

            if (info.isFinished)
            {
                continue;
            }

            if (info.CurrentHits >= info.MaxHits)
            {
                continue;
            }

            if (info.Attacker == control)
            {
                continue;
            }

            if (info.MustFaceAttacker)
            {
                Vector3 vec = this.transform.position - info.Attacker.transform.position;
                if (vec.z * info.Attacker.transform.forward.z < 0f)
                {
                    continue;
                }
            }

            if (info.MustCollide)
            {
                if (IsCollided(info))
                {
                    TakeDamage(info);
                }
            }

            else
            {
                float dist = Vector3.SqrMagnitude(this.gameObject.transform.position - info.Attacker.transform.position);
                Debug.Log(this.gameObject.name + "dist: " + dist.ToString());
                if (dist <= info.LethalRange)
                {
                    TakeDamage(info);
                }
            }
        }
    }

    private bool IsCollided(AttackInfo info)
    {
        foreach(TriggerDetector trigger in control.GetAllTriggers())
        {
            foreach (Collider collider in trigger.CollidingParts)
            {
                foreach (string name in info.ColliderNames)
                {
                    if (name == collider.gameObject.name)
                    {
                        PickDeathAnimation = trigger.deathAnimation;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void TakeDamage(AttackInfo info)
    {
        // shake camera on aoe
        if (!info.MustCollide)
        {
            CameraManager.Instance.ShakeCamera(0.25f);
        }

        Debug.Log(info.Attacker.gameObject.name + " hits: " + this.gameObject.name);
        Debug.Log(this.gameObject.name + " plays: " + PickDeathAnimation.ToString());

        //control.SkinnedMeshAnimator.runtimeAnimatorController = info.AttackAbility.GetDeathAnimator();
        control.SkinnedMeshAnimator.runtimeAnimatorController = DeathAnimationManager.Instance.GetAnimator(PickDeathAnimation, info);
        info.CurrentHits++;

        control.GetComponent<BoxCollider>().enabled = false;
        control.RIGID_BODY.useGravity = false;
    }
}
