using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20;

    public int HitPoints = 100;
    public Text HealthText;
    public int maxHitPoints = 100;

    public int ManaPoints = 100;
    public Text ManaText;
    public int maxManaPoints = 100;

    private float manaRegenTime = 1.0f;
    public float manaRegenPeriod = 1.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

		//Draw player health on screen
        HealthText.text = "Health: " + HitPoints;
        ManaText.text = "Mana: " + ManaPoints;

        //If the player dies reload the current scene
        if (HitPoints == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (ManaPoints < maxManaPoints)
        {
            if (Time.time > manaRegenTime)
            {
                manaRegenTime += manaRegenPeriod;
                ManaPoints += 1;
            }
        }
    }

	void FixedUpdate()
    {
		if (horizontal != 0 && vertical != 0) //If moving diagonally
		{
			body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
		}
		else //If not moving diagonally
		{
			body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		}
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		//If the playre colides with a projectile that is not it's own
		if (other.CompareTag("Projectile"))
		{
			Destroy(other.gameObject);
			HitPoints -= 10;
		}
	}

}
