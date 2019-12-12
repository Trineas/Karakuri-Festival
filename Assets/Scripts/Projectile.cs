using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public CharacterControl control;
    public float speed;
    public float height;
    private Rigidbody rb;
    private PoolObject poolObj;

    public void InitProjectile()
    {
        if (poolObj == null)
        {
            poolObj = this.gameObject.GetComponent<PoolObject>();
        }

        rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;

        if (control.IsFacingForward())
        {
            rb.velocity = new Vector3(speed, height, 0);
        }
        else
        {
            rb.velocity = new Vector3(-speed, height, 0);
        }

        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DamageDetector damage = other.gameObject.transform.root.GetComponent<DamageDetector>();
            AttackInfo attack = new AttackInfo();
            damage.TakeDamage(attack);

            poolObj.TurnOff();
        }

        // for enemy projectiles?
        //if (other.tag == "Player")
        // {
        //     DamageDetector damage = other.gameObject.transform.root.GetComponent<DamageDetector>();
        //     AttackInfo attack = new AttackInfo();
        //     damage.TakeDamage(attack);
        //
        //    poolObj.TurnOff();
        // }

        if (other.tag == "Geometry")
        {
            poolObj.TurnOff();
        }

        if (other.tag == "Destroyable")
        {
           // for when projectile is changing depending on variable
           // if (height > 0)
           // {
                Destroy(other.gameObject);
           // }

            poolObj.TurnOff();
        }
    }
}
