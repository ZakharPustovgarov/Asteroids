using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallAsteroid : Enemy
{
    // Rigidbody астероида
    Rigidbody2D rigidbody;

    // При активации вызывается метод движения
    void OnEnable()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();

        damageType = "Asteroid";

        destination = FindDestination();

        StartCoroutine("MoveDelay");
    }

    // На астероид подаётся сила, отправляющая его дрейфовать по направлению движения
    protected override void Move()
    {
        rigidbody.AddForce((destination.position - this.transform.position) * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    protected Transform FindDestination()
    {
        return GameObject.Find("DestinationPoint (" + (int)UnityEngine.Random.Range(0,40) + ")").transform;
    }

    IEnumerator MoveDelay()
    {
        yield return new WaitForSeconds(0.5f);

        Move();
    }

    public void ChangeDestination(Transform newDestination)
    {
        destination = newDestination;

        StopCoroutine("MoveDelay");

        Move();
    }
}
