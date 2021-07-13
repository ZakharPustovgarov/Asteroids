using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    Transform[] spawnPoints;

    int score;

    [SerializeField]
    Text scoreText;

    public bool isPlayerAlive;

    [SerializeField]
    GameObject bigAsteroidPrefab, ufoPrefab;

    [SerializeField]
    float asteroidSpawnTimer, ufoSpawnTimer;

    int previousSpawnNumber = -1;

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag != "Laser")
        {
            GameObject.Destroy(other.gameObject);
        }
    }

    void Start()
    {
        score = 0;

        isPlayerAlive = true;

        StartCoroutine("UfoSpawn");
        StartCoroutine("AsteroidSpawn");
    }

    IEnumerator UfoSpawn()
    {
        while (isPlayerAlive == true)
        {
            Transform spawn = FindSpawnPoint();

            GameObject.Instantiate(bigAsteroidPrefab, spawn.position, spawn.rotation);

            yield return new WaitForSeconds(ufoSpawnTimer);
        }      
    }

    IEnumerator AsteroidSpawn()
    {
        while (isPlayerAlive == true)
        {
            Transform spawn = FindSpawnPoint();

            GameObject.Instantiate(ufoPrefab, spawn.position, spawn.rotation);

            yield return new WaitForSeconds(asteroidSpawnTimer);
        }
    }
    
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = Convert.ToString(score);
    }

    Transform FindSpawnPoint()
    {
        int spawnNumber = (int)UnityEngine.Random.Range(0, spawnPoints.Length);

        if(spawnNumber == previousSpawnNumber)
        {
            while (spawnNumber == previousSpawnNumber)
            {
                spawnNumber = (int)UnityEngine.Random.Range(0, spawnPoints.Length);
            }
        }

        previousSpawnNumber = spawnNumber;

        return spawnPoints[spawnNumber];
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
