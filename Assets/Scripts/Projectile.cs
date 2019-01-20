using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 target;
    public float speed;

    // Use this for initialization
    void Start ()
	{
		//Sets the current mouse position as the target for the projectile
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Moves the projectile towards the target at the given speed
	    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

		//If the projectile reaaches it's target, it is destroyed
	    if (Vector2.Distance(transform.position, target) == 0)
	    {
            Destroy(gameObject);
	    }
	}
}
