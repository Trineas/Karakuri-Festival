using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed, speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DamageDetector damage = other.transform.root.gameObject.GetComponent<DamageDetector>();
            AttackInfo info = new AttackInfo();
            damage.TakeDamage(info);

            Destroy(this.gameObject);
            this.gameObject.GetComponent<PoolObject>().TurnOff();
        }

        if (other.tag == "Geometry")
        {
            Destroy(this.gameObject);
        }

        if (other.tag == "Destroyable")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
