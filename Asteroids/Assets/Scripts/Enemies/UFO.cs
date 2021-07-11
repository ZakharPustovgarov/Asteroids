using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    // В качестве направления движения указывается игрок
    void Start()
    {
        base.Start();

        destination = GameObject.FindWithTag("Player").transform;        
    }

    // Постоянно вызывается метод движения
    void FixedUpdate()
    {
        Move();
    }

    // Движения происходит в сторону игрока 
    protected override void Move()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, destination.position, speed * Time.deltaTime);
    }
}
