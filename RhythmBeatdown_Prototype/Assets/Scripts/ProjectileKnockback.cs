using UnityEngine;
using System.Collections;

public class ProjectileKnockback : MonoBehaviour {

	private Rigidbody opponent;
	private Rigidbody thisProjectile;
	public float force = 750f;
	public float upForce = 1;

	void OnCollisionEnter(Collision col)
	{

		opponent = col.gameObject.GetComponent<Rigidbody>();
		thisProjectile = this.GetComponent<Rigidbody> ();

		print (thisProjectile.velocity);

		print ("colTag"+col.gameObject.tag);



		if (col.gameObject.tag == "Player_One"  && thisProjectile.velocity.x > 0) 
		{
			int direction = 1;
			opponent.AddForce (new Vector3 (force * direction, 5, 0), ForceMode.Impulse);
			//print (thisAttack.direction);

		}
		else if (col.gameObject.tag == "Player_One" && thisProjectile.velocity.x < 0) 
		{
			int direction = -1;
			opponent.AddForce (new Vector3 (force * direction, 5, 0), ForceMode.Impulse);
			//print (thisAttack.direction);
		}

		else if(col.gameObject.tag == "Player_Two"&& thisProjectile.velocity.x > 0)
		{
			int direction = 1;
			opponent.AddForce (new Vector3(force * direction,5,0), ForceMode.Impulse);
		}
		else if(col.gameObject.tag == "Player_Two"&& thisProjectile.velocity.x < 0)
		{
			int direction = -1;
			opponent.AddForce (new Vector3(force*direction,5,0), ForceMode.Impulse);
		}

	}
}
