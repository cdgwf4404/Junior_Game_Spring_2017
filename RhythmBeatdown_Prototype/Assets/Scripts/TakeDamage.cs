using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour {
	
	public delegate void DamageAction ();
	public static event DamageAction gotHit;

	public int crowdDamage = 2;
	private int crescendoIncrease = 5;

	public Slider CrescendoSlider;


    void OnCollisionEnter(Collision col)
    {
		
		if (col.gameObject.layer == LayerMask.NameToLayer("projectiles"))
        {

            if (this.gameObject.tag == "Player_Two")
            {
                Damage(tag);
				print ("Hit P2");

            }
        }

		if (col.gameObject.layer == LayerMask.NameToLayer("projectiles"))
        { 
            if (this.gameObject.tag == "Player_One")
            {
                Damage(tag);
				print ("Hit P1");
            }
        }
			
			//if (col.gameObject.name == "High2" && this.gameObject.tag == "Player_One") {
			//	Lists.p2aprojectilelist.Remove (col.gameObject);
			//	Destroy (col.gameObject);
			//	Damage ();

			//} else if (col.gameObject.name == "High" && this.gameObject.tag == "Player_Two") {
			//	Lists.p1aprojectilelist.Remove (col.gameObject);
			//	Destroy (col.gameObject);
			//	Damage ();

			//} else if (col.gameObject.name == "Mid2" && this.gameObject.tag == "Player_One") {
			//	Lists.p2aprojectilelist.Remove (col.gameObject);
			//	Destroy (col.gameObject);
			//	Damage ();

			//} else if (col.gameObject.name == "Mid" && this.gameObject.tag == "Player_Two") {
			//	Lists.p1aprojectilelist.Remove (col.gameObject);
			//	Destroy (col.gameObject);
			//	Damage ();

			//	//Destroy (gameObject, bulletlife);  
			//} else if (col.gameObject.name == "Low2" && this.gameObject.tag == "Player_One") {
			//	Lists.p2aprojectilelist.Remove (col.gameObject);
			//	Destroy (col.gameObject);
			//	Damage ();

			//} else if (col.gameObject.name == "Low" && this.gameObject.tag == "Player_Two") {
			//	Lists.p1aprojectilelist.Remove (col.gameObject);
			//	Destroy (col.gameObject);
			//	Damage ();


			//}


		//}
		
	}
    
	
//	void OnCollisionEnter(Collision other)
//	{
////		
////		if (other.gameObject.tag == "projectile") {
////			
////			if (other.gameObject.name == "High2") {
////				Lists.p2aprojectilelist.Remove (other.gameObject);
////
////			} else if (other.gameObject.name == "High") {
////				Lists.p1aprojectilelist.Remove (other.gameObject);
////
////			} else if (other.gameObject.name == "Mid2") {
////				Lists.p2aprojectilelist.Remove (other.gameObject);
////
////			} else if (other.gameObject.name == "Mid") {
////				Lists.p1aprojectilelist.Remove (other.gameObject);
////
////				//Destroy (gameObject, bulletlife);  
////			} else if (other.gameObject.name == "Low2") {
////				Lists.p2aprojectilelist.Remove (other.gameObject);
////
////			} else if (other.gameObject.name == "Low") {
////				Lists.p1aprojectilelist.Remove (other.gameObject);
////
////
////			}
////			Damage ();
////			Destroy (other.gameObject);
////		}
//	}
	
	void OnEnable()
	{
		HitCollider.TakeDamage += Damage;
	}

	void OnDisable()
	{
		HitCollider.TakeDamage -= Damage;
	}

	public void Damage(string tag)
	{
		//slowing time event called
		//		SlowingTime();

		if (tag == "Player_Two") {
			if (gotHit != null)
			{
				gotHit ();
			}
			CrowdMeter.currentCrowdState -= crowdDamage;
			Crescendo.crescendoVal1 += crescendoIncrease;

			if (CrescendoSlider.value == CrescendoSlider.maxValue) 
			{
				//CrescendoSlider.image.color = Color.red;
			}


		} else if (tag == "Player_One") {
			if (gotHit != null)
			{
				gotHit ();
			}
			CrowdMeter.currentCrowdState += crowdDamage;
			Crescendo.crescendoVal2 += crescendoIncrease;
		}
	}
}