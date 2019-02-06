using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float runSpeed;
    private Transform playerPosistion;
    private Player player;
	private Rigidbody2D rb;
	public float enemyDrag = 0.01f;

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
		rb = GetComponent<Rigidbody2D>();
		rb.drag = enemyDrag;
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
