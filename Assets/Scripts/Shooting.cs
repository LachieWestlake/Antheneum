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
	    if (Time.time >= timestamp && Input.GetMouseButton(0))
	    {
            Instantiate(magic, playerPosistion.position, Quaternion.identity);
	        timestamp = Time.time + timeBetweenShots;
        }
	}
}
