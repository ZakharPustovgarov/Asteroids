using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersGun : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    Transform fireDirection;
    [SerializeField]
    Transform ship;

    [SerializeField]
    GameObject laserPolyPrefab, laserSpritePrefab;
    [SerializeField]
    GameObject bulletPolyPrefab, bulletSpritePrefab;
    public float bulletSpeed = 8f;
    public float bulletCooldown = 0.2f;

    public float laserExparationTime = 4f;
    float timer = 0f;
    bool isShootingLaser = false;

    PlayerManager playerManager;

    GameManager gameManager;

    [SerializeField]
    public Sprite otherSprite;

    void Start()
    {
        playerManager = PlayerManager.Instance;

        gameManager = GameManager.Instance;

        isShootingLaser = false;
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Fire(int fireMode)
    {
        if(fireMode == 1 && timer <= 0 && isShootingLaser == false)
        {
            Bullet bullet;
            if(gameManager.Visualization == false) bullet = GameObject.Instantiate(bulletPolyPrefab, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Bullet>();
            else bullet = GameObject.Instantiate(bulletSpritePrefab, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Bullet>();

            Vector2 vec = fireDirection.position - firePoint.position;

            bullet.GetComponent<Rigidbody2D>().AddForce(vec * bulletSpeed);

            timer = bulletCooldown;
        }
        else if(fireMode == 2 && isShootingLaser == false && playerManager.laserCount > 0)
        {
            StartCoroutine("CreateLaser");
        }
    }

    IEnumerator CreateLaser()
    {
        isShootingLaser = true;

        playerManager.LaserUsed();

        GameObject laser;

        if (gameManager.Visualization == false) laser = GameObject.Instantiate(laserPolyPrefab, firePoint);
        else laser = GameObject.Instantiate(laserSpritePrefab, firePoint);

        yield return new WaitForSeconds(laserExparationTime);

        GameObject.Destroy(laser);

        isShootingLaser = false;
    }
}
