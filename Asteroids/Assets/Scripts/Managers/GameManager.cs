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
    GameObject bigAsteroidPolyPrefab, ufoPolyPrefab, bigAsteroidSpritePrefab, ufoSpritePrefab;

    [SerializeField]
    float asteroidSpawnTimer, ufoSpawnTimer;

    int previousSpawnNumber = -1;

    bool visualization;

    public bool Visualization
    { get { return visualization; } }

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

            if (visualization == false) GameObject.Instantiate(bigAsteroidPolyPrefab, spawn.position, spawn.rotation);          
            else GameObject.Instantiate(bigAsteroidSpritePrefab, spawn.position, spawn.rotation);


            yield return new WaitForSeconds(ufoSpawnTimer);
        }      
    }

    IEnumerator AsteroidSpawn()
    {
        while (isPlayerAlive == true)
        {
            Transform spawn = FindSpawnPoint();

            if (visualization == false)  GameObject.Instantiate(ufoPolyPrefab, spawn.position, spawn.rotation);
            else GameObject.Instantiate(ufoSpritePrefab, spawn.position, spawn.rotation);

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

    public void ChangeVisualization()
    {
        visualization = !visualization;

        var damagingObjects = FindObjectsOfType<DoDamage>();    

        if(damagingObjects != null)
        {
            UnityEngine.Debug.Log(damagingObjects.Length);

            foreach (var obj in damagingObjects)
            {
                obj.ReplaceSprite();
            }
        }

        //var enemyObjects = FindObjectsOfType<Enemy>();

        //if (enemyObjects != null)
        //{
        //    Unity
        //    foreach (var obj in enemyObjects)
        //    {
        //        obj.ReplaceSprite();
        //    }
        //}
    }
}
