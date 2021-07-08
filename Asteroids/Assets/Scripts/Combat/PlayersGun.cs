using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGun : MonoBehaviour
{
    [SerializeField]
    Transform m_firePoint;
    [SerializeField]
    Transform m_fireDirection;
    [SerializeField]
    Transform m_ship;

    [SerializeField]
    GameObject m_laserPrefab;
    [SerializeField]
    GameObject m_bulletPrefab;
    public float m_bulletSpeed = 8f;
    public float m_bulletCooldown = 0.2f;

    public float laserExparationTime = 4f;
    float m_timer = 0f;
    bool isShootingLaser = false;

    void Start()
    {
        isShootingLaser = false;
    }

    void Update()
    {
        if(m_timer > 0)
        {
            m_timer -= Time.deltaTime;
        }
    }

    public void Fire(int fireMode)
    {
        if(fireMode == 1 && m_timer <= 0 && isShootingLaser == false)
        {
            Bullet bullet = GameObject.Instantiate(m_bulletPrefab, m_firePoint.transform.position, m_firePoint.transform.rotation).GetComponent<Bullet>();

            Vector2 vec = m_fireDirection.position - m_firePoint.position;

            bullet.GetComponent<Rigidbody2D>().AddForce(vec * m_bulletSpeed);

            m_timer = m_bulletCooldown;
        }
        else if(fireMode == 2 && isShootingLaser == false)
        {
            StartCoroutine("CreateLaser");
        }
    }

    IEnumerator CreateLaser()
    {
        isShootingLaser = true;

        GameObject laser = GameObject.Instantiate(m_laserPrefab, m_firePoint);     

        yield return new WaitForSeconds(laserExparationTime);

        GameObject.Destroy(laser);

        isShootingLaser = false;
    }
}
