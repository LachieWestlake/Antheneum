using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject magic;
    private Transform playerPosistion;
    public float timeBetweenShots = 0.1111f;  // Allow 3 shots per second
    private float timestamp;

    void Start ()
	{
	    playerPosistion = GetComponent<Transform>();
	}
	
	void Update () {
		//If the time between shots has passed and the left mouse button is clicked
	    if (Time.time >= timestamp && Input.GetMouseButton(0))
	    {
			//Create a new projectile at the players current position
            Instantiate(magic, playerPosistion.position, Quaternion.identity);
			//Creates a time stamp for when the next projectile can be fired
			timestamp = Time.time + timeBetweenShots;
        }
	}
}
