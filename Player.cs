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

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        HealthText.text = "Health: " + HitPoints;
        if (HitPoints == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
        }
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
}
