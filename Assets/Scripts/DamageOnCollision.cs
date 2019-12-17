using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DamageDetector damage = other.gameObject.transform.root.GetComponent<DamageDetector>();
            AttackInfo attack = new AttackInfo();
            damage.TakeDamage(attack);
        }
    }
}
