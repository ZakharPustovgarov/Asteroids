using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField]
    protected string m_damageType = "";

    void OnTriggerEnter(Collider other)
    {       

        if(other.tag == "Enemy")
        {
            Damage(other);
        }
    }

    protected virtual void Damage(Collider enemy)
    {
        enemy.GetComponent<IDamagable>().TakeDamage(m_damageType);
    }

}
