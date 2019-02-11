using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int manaCost;
    public int shotSize;
    public int shotSpeed;
    public int shotDistance;
    public int shotDamage;
    public float timeBetweenShots = 0.1111f;  // Allow 3 shots per second
    public GameObject magic;

    private Transform playerPosistion;
    private float timestamp;

    void Start ()
	{
        playerPosistion = GetComponent<Transform>();
	}
	
	void Update () {
		//If the time between shots has passed and the left mouse button is clicked
	    if (Time.time >= timestamp && Input.GetMouseButton(0))
	    {
            //Create a new projectile at the players current position that moves towards the target (mouse position)
	        GameObject playerProjectile = Instantiate(magic, playerPosistion.position, Quaternion.identity);

            Projectile Holder = playerProjectile.GetComponent<Projectile>();
	        Holder.Damage = shotDamage;

	        playerProjectile.GetComponent<Rigidbody2D>().velocity = ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPosistion.position)/Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), playerPosistion.position)) * shotSpeed;
            //Creates a time stamp for when the next projectile can be fired
            timestamp = Time.time + timeBetweenShots;
        }
	}
}
