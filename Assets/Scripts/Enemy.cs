using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float runSpeed;
    private Transform playerPosistion;
    private Player player;

	public Transform PlayerPosistion
	{
		get
		{
			return playerPosistion;
		}
	}

	public Player Player
	{
		get
		{
			return player;
		}
		set
		{
			player = value;
		}
	}

	public void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPosistion = player.GetComponent<Transform>();
    }
	
	public void Move ()
	{
		//Moves towards the player at the given speed
	    transform.position = Vector2.MoveTowards(transform.position, playerPosistion.position, runSpeed * Time.deltaTime);
	}

	//If the enemy colides with a projectile
    void OnTriggerEnter2D(Collider2D other)
    {
		//If the enemy colides with a projectile
        if (other.CompareTag("Player Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
