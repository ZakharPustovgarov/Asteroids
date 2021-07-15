using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : DoDamage
{
    [SerializeField]
    float selfDestroyTime = 5f;

    void OnEnable()
    {
        damageType = "Bullet";

        StartCoroutine("SelfDestroy");
    }

    protected override void Damage(Collider2D enemy)
    {
        base.Damage(enemy);
        GameObject.Destroy(this.gameObject);
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(selfDestroyTime);

        GameObject.Destroy(this.gameObject);
    }
}
