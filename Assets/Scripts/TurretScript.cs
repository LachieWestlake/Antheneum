using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : Enemy{

	public GameObject projectile;
	public int projectileVelocity;
	public float timeBetweenShots = 0.5f;  // Allow 2 shots per second
	public float lockOnRange = 4f;
	private float timestamp = 0f;

	private new void Start()
	{
		base.Start();
		runSpeed = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= timestamp && Vector2.Distance(PlayerPosistion.position, transform.position) < lockOnRange)
		{
			//Create a new projectile at the turrets current position that moves towards the target (player)
			GameObject output = Instantiate(projectile, transform.position, Quaternion.identity);
			output.GetComponent<Rigidbody2D>().velocity = ((PlayerPosistion.position - transform.position) / Vector2.Distance(PlayerPosistion.position, transform.position)) * projectileVelocity;

			timestamp = Time.time + timeBetweenShots;
		}
	}
}
