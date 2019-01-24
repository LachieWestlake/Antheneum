using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy {

	public float timeBetweenHits = 0.5f;  // Allow 2 shots per second
	public float meleeRange = 3f;
	private float timestamp = 0f;
	
	// Update is called once per frame
	void Update () {

		Move();

		Debug.Log(Vector2.Distance(PlayerPosistion.position, transform.position));
		if (Vector2.Distance(PlayerPosistion.position, transform.position) < meleeRange)
			Debug.Log("REEEEEEE");

		if (Time.time >= timestamp && Vector2.Distance(PlayerPosistion.position, transform.position) < meleeRange)
		{
			Player.HitPoints -= 10;

			timestamp = Time.time + timeBetweenHits;
		}
	}
}
