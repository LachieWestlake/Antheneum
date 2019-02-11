using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : Enemy
{
    public GameObject enemy;
    private float currentTimeBtwSpawns;
    public float startTimeBtwSpawn;
    //public Text enemyAmount;

    new void Start ()
	{
		base.Start();
	    currentTimeBtwSpawns = startTimeBtwSpawn;
	}
	
	void Update () {
		//If it is time to spawn a new enemy
	    if (currentTimeBtwSpawns <= 0)
	    {
			//Creates a new enemy at the chosen pooint
	        Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
	        currentTimeBtwSpawns = startTimeBtwSpawn;
	    }
	    else
	    {
	        currentTimeBtwSpawns -= Time.deltaTime;
	    }
	}
}
