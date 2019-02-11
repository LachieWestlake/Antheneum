using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance { get; private set; }
	public Player player;
	private GameObject[] arrayOfEnemies;
	public Text enemyAmount;

	void Awake()
	{
		if (instance != null) throw new System.Exception();
		instance = this;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		arrayOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		//Writes the amount of enemies to the screen
		enemyAmount.text = "Enemies: " + arrayOfEnemies.Length;
	}
}
