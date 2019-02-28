using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public HealthBar healthBar;
    public float runSpeed;
    private Transform playerPosistion;
    private Player player;
	private Rigidbody2D rb;
	public float enemyDrag = 0.01f;
	public int hitPoints = 20;
	private int maxHealth;
	public int movementRange;

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
		maxHealth = hitPoints;
    }

	bool CanSeePlayer ()
	{
		Vector2 direction = (playerPosistion.position - transform.position).normalized;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, movementRange, 1 << 8 | 1 << 10);

		Debug.DrawRay(transform.position, direction, Color.red, 3f);

		if (hit.collider != null)
			Debug.Log(hit.collider.name);
		else
			Debug.Log("Missed everything just like your goals in life");

		if (hit.collider)
			//If the raycast hits the player
			if (hit.collider.tag == "Player")
			{
				Debug.Log("Success!!!");
				return true;
			}

			return false;
	}

	private void FixedUpdate()
	{
		Move();
	}

	public void Move ()
	{
		if ((Vector2.Distance(PlayerPosistion.position, transform.position) < movementRange) && CanSeePlayer())
		{
			//Moves towards the player at the given speed
			transform.position = Vector2.MoveTowards(transform.position, playerPosistion.position, runSpeed * Time.deltaTime);
		}
	}

	public void UpdateHealth()
	{
		healthBar.SetSize((float)hitPoints/maxHealth);
	}

	//If the enemy colides with a projectile
    void OnTriggerEnter2D(Collider2D other)
    {
		//If the enemy colides with a projectile
        if (other.CompareTag("Player Projectile"))
        {
            Destroy(other.gameObject);
            Projectile playerShot = other.GetComponent<Projectile>();
            hitPoints -= playerShot.Damage;
			if (hitPoints <= 0)
				Destroy(gameObject);

			UpdateHealth();
        }
    }
}
