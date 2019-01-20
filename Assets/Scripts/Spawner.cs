using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    private float currentTimeBtwSpawns;
    public float startTimeBtwSpawn;
    public Text enemyAmount;
    private GameObject[] arrayOfEnemies;

    void Start ()
	{
	    currentTimeBtwSpawns = startTimeBtwSpawn;
	}
	
	void Update () {
		//If it is time to spawn a new enemy
	    if (currentTimeBtwSpawns <= 0)
	    {
			//Chooses a random spawn point for the enemy
	        int randPos = Random.Range(0, spawnPoints.Length);
			//Creates a new enemy at the chosen pooint
	        Instantiate(enemy, spawnPoints[randPos].position, Quaternion.identity);
	        currentTimeBtwSpawns = startTimeBtwSpawn;
	    }
	    else
	    {
	        currentTimeBtwSpawns -= Time.deltaTime;
	    }
		
		//an array of all enemies that currently exist
	    arrayOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		//Writes the amount of enemies to the screen
	    enemyAmount.text = "Enemies: " + arrayOfEnemies.Length;
	}
}
