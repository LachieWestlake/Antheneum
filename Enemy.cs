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
        playerPosistion = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	void Update ()
	{
	    transform.position = Vector2.MoveTowards(transform.position, playerPosistion.position, runSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.HitPoints -= 10;
            Destroy(gameObject);
        }
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
