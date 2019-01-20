using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float runSpeed;
    private Transform playerPosistion;
    private Player player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosistion = player.GetComponent<Transform>();
    }
	
	void Update ()
	{
		//Moves towards the player at the given speed
	    transform.position = Vector2.MoveTowards(transform.position, playerPosistion.position, runSpeed * Time.deltaTime);
	}

	//If the enemy colides with anything
    void OnTriggerEnter2D(Collider2D other)
    {
		//If the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            player.HitPoints -= 10;
            Destroy(gameObject);
        }

		//If the enemy colides with a projectile
        else if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
