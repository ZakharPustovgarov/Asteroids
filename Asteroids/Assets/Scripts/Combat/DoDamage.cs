using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DoDamage : MonoBehaviour
{
    protected string damageType = "";

    void OnTriggerEnter(Collider other)
    {       

        if(other.tag == "Enemy")
        {
            Damage(other);
        }
    }

    protected virtual void Damage(Collider enemy)
    {
        enemy.GetComponent<IDamagable>().TakeDamage(damageType);
    }

}
