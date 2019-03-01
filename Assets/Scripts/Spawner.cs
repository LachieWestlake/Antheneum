using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : Enemy
{
    public GameObject enemy;
    private float currentTimeBtwSpawns;
    public float startTimeBtwSpawn;
	private List<GameObject> enemiesSpawned;
	public int maxEnemies;

    new void Start ()
	{
		base.Start();
	    currentTimeBtwSpawns = startTimeBtwSpawn;
		enemiesSpawned = new List<GameObject>();
		runSpeed = 0;
	}
	
	void Update () {

		//Removes dead enemies from the list of enemies spawned
		//Iterated backwards through the loop so that it doesn't fuck up
		for (int i = enemiesSpawned.Count - 1; i >= 0; i--)
			if (enemiesSpawned[i] == null)
				enemiesSpawned.Remove(enemiesSpawned[i]);

		//If it is time to spawn a new enemy
	    if (currentTimeBtwSpawns <= 0 && enemiesSpawned.Count < maxEnemies)
	    {
			//Creates a new enemy at the chosen point and adds it to the list of enemies spawned from this spawner
	        enemiesSpawned.Add(Instantiate(enemy, gameObject.transform.position, Quaternion.identity));
	        currentTimeBtwSpawns = startTimeBtwSpawn;
	    }
	    else
	    {
	        currentTimeBtwSpawns -= Time.deltaTime;
	    }
	}
}
