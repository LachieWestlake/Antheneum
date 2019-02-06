﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy {

	public float timeBetweenHits = 0.5f;  // Allow 2 shots per second
	public float meleeRange = 1.5f;
	private float timestamp = 0f;
	
	// Update is called once per frame
	void Update () {

		Move();

		if (Time.time >= timestamp && Vector2.Distance(PlayerPosistion.position, transform.position) < meleeRange)
		{
			Player.HitPoints -= 10;

			timestamp = Time.time + timeBetweenHits;
		}
	}
}