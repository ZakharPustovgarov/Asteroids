using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    //Положение
    Transform m_transform;
    float m_rotate;
    public float m_rotateModifier = 1.0f;

    //Передвижение
    public float speedModifier = 3.0f;
    float m_vertical = 0f, m_horizontal = 0f;
    Rigidbody2D m_rigidbody;

    private bool m_isDead;

    //Настройка клавиш
    KeyCode m_strafeLeft = KeyCode.A;
    KeyCode m_strafeRight = KeyCode.D;
    KeyCode m_forward = KeyCode.W;
    KeyCode m_backward = KeyCode.S;
    KeyCode m_rotateRigth = KeyCode.E;
    KeyCode m_rotateLeft = KeyCode.Q;

    KeyCode m_fireBullets = KeyCode.UpArrow;
    KeyCode m_fireLaser = KeyCode.DownArrow;

    // Start is called before the first frame update
    void Start()
    {
        m_isDead = false;

        m_transform = this.transform;

        m_rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isDead != true)
        {
            m_horizontal = Input.GetAxis("Horizontal");
            m_vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(m_rotateLeft))
            {
                this.transform.Rotate(0, 0, m_rotateModifier * Time.deltaTime);
            }
            if (Input.GetKey(m_rotateRigth))
            {
                this.transform.Rotate(0, 0, -m_rotateModifier * Time.deltaTime);
            }

            if (Input.GetKeyDown(m_fireBullets))
            {

            }
            if (Input.GetKeyDown(m_fireLaser))
            {

            }

            Move();
        }
    }

    void Move()
    {
        if(m_horizontal != 0)
        {
            m_rigidbody.AddForce(new Vector2(m_horizontal * speedModifier, 0));
        }
        if (m_vertical != 0)
        {
            m_rigidbody.AddForce(new Vector2(0, m_vertical * speedModifier));
        }
    }

    public void TakeDamage(string damageType)
    {
        if(damageType == "Asteroid" || damageType == "UFO")
        {
            Die();
        }
    }

    void Die()
    {

    }
}


