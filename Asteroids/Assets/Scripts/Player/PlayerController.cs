using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamagable
{
    //Положение
    float rotate;
    public float rotateModifier = 1.0f;

    //Передвижение
    public float speedModifier = 3.0f;
    float vertical = 0f, horizontal = 0f;
    Rigidbody2D rigidbody;

    private bool isDead;

    //Настройка клавиш
    KeyCode strafeLeft = KeyCode.A;
    KeyCode strafeRight = KeyCode.D;
    KeyCode forward = KeyCode.W;
    KeyCode backward = KeyCode.S;
    KeyCode rotateRigth = KeyCode.E;
    KeyCode rotateLeft = KeyCode.Q;

    KeyCode fireBullets = KeyCode.Keypad1;
    KeyCode fireLaser = KeyCode.Keypad2;

    //Стрельба
    [SerializeField]
    PlayersGun gun;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;

        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead != true)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(rotateLeft))
            {
                this.transform.Rotate(0, 0, rotateModifier * Time.deltaTime);
            }
            if (Input.GetKey(rotateRigth))
            {
                this.transform.Rotate(0, 0, -rotateModifier * Time.deltaTime);
            }

            if (Input.GetKey(fireBullets))
            {
                gun.Fire(1);
            }
            if (Input.GetKeyDown(fireLaser))
            {
                gun.Fire(2);
            }

            Move();
        }
    }

    void Move()
    {
        if(horizontal != 0)
        {
            rigidbody.AddForce(new Vector2(horizontal * speedModifier, 0));
        }
        if (vertical != 0)
        {
            rigidbody.AddForce(new Vector2(0, vertical * speedModifier));
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
        isDead = true;

        PlayerManager.Instance.OnDeath();

        UnityEngine.Debug.Log("Player is dead...");
    }
}


