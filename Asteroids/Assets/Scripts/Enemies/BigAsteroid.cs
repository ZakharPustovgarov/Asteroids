using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : SmallAsteroid
{
    [SerializeField]
    Transform[] directions;

    [SerializeField]
    GameObject smallAsteroidPrefab;

    public override void TakeDamage(string damageType)
    {
        if(damageType != "Laser")
        {
            int count = (int)UnityEngine.Random.Range(1, 3);

            List<int> occupiedDirections = new List<int>();

            for (int i = 0; i < count; i++)
            {
                SmallAsteroid asteroid = GameObject.Instantiate(smallAsteroidPrefab, this.transform.position, this.transform.rotation).GetComponent<SmallAsteroid>();

                int directionNumber = FindFreeDirection(occupiedDirections);

                asteroid.speed *= 4f;

                occupiedDirections.Add(directionNumber);

                asteroid.ChangeDestination(directions[directionNumber]);
            }
        }     

        GameObject.Destroy(this.gameObject);
    }

    int FindFreeDirection(List<int> occupiedDirections)
    {
        int directionNumber = (int)UnityEngine.Random.Range(0, 11);

        if(directions.Length == 0)
        {
            return directionNumber;
        }
        else
        {
            while(occupiedDirections.Contains(directionNumber))
            {
                directionNumber = (int)UnityEngine.Random.Range(0, 11);
            }

            return directionNumber;
        }
    }
}
