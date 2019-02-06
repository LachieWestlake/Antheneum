using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Use this for initialization
    void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	//If the projectile collides with anything
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Immovable Object"))
			Destroy(gameObject);
	}
}
