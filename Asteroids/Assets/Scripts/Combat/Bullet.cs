using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DoDamage
{
    void Awake()
    {
        damageType = "Bullet";
    }

    void OnEnable()
    {
        StartCoroutine("SelfDestroy");
    }

    protected override void Damage(Collider2D enemy)
    {
        base.Damage(enemy);
        GameObject.Destroy(this.gameObject);
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(4f);
        GameObject.Destroy(this.gameObject);
    }
}
