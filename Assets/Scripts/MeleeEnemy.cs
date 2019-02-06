using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {

	public float speed = 3f;
	public float timeBetweenHits = 0.5f;  // Allow 2 shots per second
	public float meleeRange = 2f;
	private float timestamp = 0f;
	
	// Update is called once per frame
	void Update () {

		float distanceFromPlayer = Vector2.Distance(PlayerPosistion.position, transform.position);

		if (distanceFromPlayer > meleeRange)
			Move();

		if (Time.time >= timestamp && distanceFromPlayer < meleeRange)
		{
			Player.HitPoints -= 10;

			timestamp = Time.time + timeBetweenHits;
		}
	}
}
