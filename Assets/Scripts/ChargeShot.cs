using UnityEngine;
using System;

public class ChargeShot : Shooting
{
    public float chargeStart;
    public float chargeMulti;

    void Start ()
	{
	    playerPosistion = GetComponent<Transform>();
    }
	
	void Update () {
	    Player playerHolder = this.gameObject.GetComponent<Player>();

	    if (Input.GetMouseButtonDown(0))
	        chargeStart = Time.time;

	    if (Input.GetMouseButtonUp(0) && Time.time - chargeStart > 1f)
	    {
	        chargeMulti = Time.time - chargeStart;
	        if (Time.time >= timestamp && playerHolder.ManaPoints >= manaCost)
	        {
	            GameObject playerProjectile = Instantiate(magic, playerPosistion.position, Quaternion.identity);
	            Projectile Holder = playerProjectile.GetComponent<Projectile>();
	            Holder.Damage = (int)Math.Round(shotDamage * chargeMulti);
                Holder.transform.localScale += new Vector3(0.2F * chargeMulti, 0.2F * chargeMulti, 0);
                playerProjectile.GetComponent<Rigidbody2D>().velocity = ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPosistion.position) / Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), playerPosistion.position)) * (int)Math.Round(shotSpeed * chargeMulti);
                timestamp = Time.time + timeBetweenShots;
	            playerHolder.ManaPoints -= manaCost;
	        }
        }
    }
}
