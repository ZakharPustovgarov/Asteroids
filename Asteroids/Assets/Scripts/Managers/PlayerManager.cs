using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [SerializeField]
    Animation animDeathScreen;

    [SerializeField]
    Text laserCountText;

    PlayerController player;

    bool isPlayerAlive;

    public int laserCount, maxLaserCount = 4;

    [SerializeField]
    float laserRechargeTime = 17f;

    bool isRecharging;

    // Start is called before the first frame update
    void Start()
    {
        isRecharging = false;

        isPlayerAlive = true;

        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        laserCount = maxLaserCount;
    }

    public void OnDeath()
    {
        if (isPlayerAlive == true)
        {
            isPlayerAlive = false;

            GameManager.Instance.isPlayerAlive = false;

            animDeathScreen.Play();
        }    
    }
    
    void UpdateLaserCount()
    {
        laserCountText.text = Convert.ToString(laserCount);
    }

    public void LaserUsed()
    {
        laserCount--;

        UpdateLaserCount();

        if (isRecharging == false)
        {
            StartCoroutine("LaserRecharge");
        }       
    }

    IEnumerator LaserRecharge()
    {
        isRecharging = true;

        while(laserCount < maxLaserCount)
        {
            yield return new WaitForSeconds(laserRechargeTime);

            laserCount++;

            UpdateLaserCount();
        }

        isRecharging = false;
    }
}
