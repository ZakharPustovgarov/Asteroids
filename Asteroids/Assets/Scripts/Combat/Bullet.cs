using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DoDamage
{
    void Awake()
    {
        damageType = "Bullet";
    }

    protected override void Damage(Collider enemy)
    {
        base.Damage(enemy);
        GameObject.Destroy(this.gameObject);
    }
}
