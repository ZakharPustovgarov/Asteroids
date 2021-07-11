using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : Enemy
{
    // � �������� ����������� �������� ����������� �����
    void Start()
    {
        base.Start();

        destination = GameObject.FindWithTag("Player").transform;        
    }

    // ��������� ���������� ����� ��������
    void FixedUpdate()
    {
        Move();
    }

    // �������� ���������� � ������� ������ 
    protected override void Move()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, destination.position, speed * Time.deltaTime);
    }
}
