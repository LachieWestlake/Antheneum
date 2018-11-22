using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    private float timeBtwSpawns;
    public float startTimeBtwSpawn;
    public Text enemyAmount;
    private GameObject[] enemyAmountArray;

    void Start ()
	{
	    timeBtwSpawns = startTimeBtwSpawn;
	}
	
	void Update () {
	    if (timeBtwSpawns <= 0)
	    {
	        int randPos = Random.Range(0, spawnPoints.Length);
	        Instantiate(enemy, spawnPoints[randPos].position, Quaternion.identity);
	        timeBtwSpawns = startTimeBtwSpawn;
	    }
	    else
	    {
	        timeBtwSpawns -= Time.deltaTime;
	    }
	    enemyAmountArray = GameObject.FindGameObjectsWithTag("Enemy");
	    enemyAmount.text = "Enemies: " + enemyAmountArray.Length;
	}
}
