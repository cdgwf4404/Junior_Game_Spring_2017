using UnityEngine;
using System.Collections;

public class StandardAttacks : MonoBehaviour
{
	
	public GameObject otherPlayer;
	public GameObject projectileH;
	public GameObject projectileM;
	public GameObject projectileL;
	public GameObject projectileLV2;
	public GameObject p1SpawnPointH;
	public GameObject p1SpawnPointM;
	public GameObject p1SpawnPointL;
	public GameObject p2SpawnPointH;
	public GameObject p2SpawnPointM;
	public GameObject p2SpawnPointL;

	public GameObject[] attackTriggers;

	public float direction = 1f;

	public float projectileHighUp = 15f;
	public float projectileMedUp = 6f;
	public float projectileLowUp = 3f;

	public float projectileSpeedHigh = 7f;
	public float projectileSpeedMed = 16f;
	public float projectileSpeedLow = 20f;

	//Melee Effect variables
	public GameObject L_Hand_Trail;
	public GameObject R_Hand_Trail;
//	public GameObject L_Foot_Trail;
	public GameObject R_Foot_Trail;


	public InputManager inputM;

	public int attackCount = 0;

	private Animator anim;
	private Fighter fighter;

	private bool lowSwitch = false;
	private bool medSwitch = false;
	private bool highSwitch = false;
	public bool canChain = false;

	public bool manualGate = false;


	public bool window = false;
	public bool attack = false;
	public int subCt = 0;
	int atkCt = 0;
	private int projectileCounter = 0;

	void Start ()
	{
		anim = this.GetComponent<Animator> ();
		fighter = this.GetComponent<Fighter> ();

		//start game with Melee VFX disabled
		L_Hand_Trail.SetActive (false);
		R_Hand_Trail.SetActive (false);
//		L_Foot_Trail.SetActive (false);
		R_Foot_Trail.SetActive (false);
	}

	void Update()
	{
		//if (Input.GetKeyDown (KeyCode.P))
			//subCt = 0;
			//UnSubscribe ();
		
	}

	void OnEnable()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A += LowAttack;
			InputManager.P1_X += MedAttack;
			InputManager.P1_Y += HighAttack;
			//InputManager.P1_B += Dodge;
			InputManager.P1_RangedA += RangedLowAttack;
			InputManager.P1_RangedX += RangedMedAttack;
			InputManager.P1_RangedY += RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A += LowAttack;
			InputManager.P2_X += MedAttack;
			InputManager.P2_Y += HighAttack;
			//InputManager.P2_B += Dodge;
			InputManager.P2_RangedA += RangedLowAttack;
			InputManager.P2_RangedX += RangedMedAttack;
			InputManager.P2_RangedY += RangedHighAttack;
		}
	}

	void OnDisable()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A -= LowAttack;
			InputManager.P1_X -= MedAttack;
			InputManager.P1_Y -= HighAttack;
			//InputManager.P1_B -= Dodge;
			InputManager.P1_RangedA -= RangedLowAttack;
			InputManager.P1_RangedX -= RangedMedAttack;
			InputManager.P1_RangedY -= RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A -= LowAttack;
			InputManager.P2_X -= MedAttack;
			InputManager.P2_Y -= HighAttack;
			//InputManager.P2_B -= Dodge;
			InputManager.P2_RangedA -= RangedLowAttack;
			InputManager.P2_RangedX -= RangedMedAttack;
			InputManager.P2_RangedY -= RangedHighAttack;
		}
	}

	void LowAttack ()
	{
		PlayerDirection ();
		atkCt++;
		print (atkCt);
		//AttackCheck ();
//			ChainCheck ();

		//if (anim.GetBool ("Chain"))
		//{
			//attackCount = 0;
//		/*BoteManager.onBote == true &&*/ attackCount < 1
		if (fighter.grounded && BoteManager.onBote == true)
		{
			AttackCheck ();
//			if (window)
//			{
				//attackCount++;
				if (lowSwitch == false)
				{
					anim.SetTrigger ("LowAttack1");
					R_Foot_Effect ();
					lowSwitch = !lowSwitch;

				{
					attackTriggers [0].SetActive (false);//The HitColliders on the legs
					attackTriggers [1].SetActive (false);
				}

				}
				else
				{
					anim.SetTrigger ("LowAttack2");
					R_Foot_Effect ();
					lowSwitch = !lowSwitch;

				attackTriggers [0].SetActive (false);//The HitColliders on the legs
				attackTriggers [1].SetActive (false);
				}
		//	}

		}
		//}
	}

	void MedAttack ()
	{
		//AttackCheck ();
//		ChainCheck ();
		//attackCount = 0;
		PlayerDirection();
		if (fighter.grounded && BoteManager.onBote == true)
		{
			AttackCheck ();
			//attackCount++;
			if (medSwitch == false)
			{
				anim.SetTrigger ("MedAttack1");
				R_Hand_Effect();
				medSwitch = !medSwitch;
				attackTriggers [2].SetActive (false);//The HitColliders on the Hands
				attackTriggers [3].SetActive (false);
			}
			else
			{
				anim.SetTrigger ("MedAttack2");
				L_Hand_Effect();
				medSwitch = !medSwitch;
				attackTriggers [2].SetActive (false);//The HitColliders on the Hands
				attackTriggers [3].SetActive (false);
			}

		}

	}

	void HighAttack ()
	{
		//AttackCheck ();
//		ChainCheck ();
		//attackCount = 0;
		PlayerDirection();
		if (fighter.grounded && BoteManager.onBote == true)
		{
			AttackCheck ();
			//attackCount++;
			if (highSwitch == false)
			{
				anim.SetTrigger ("HighAttack1");
				R_Hand_Effect ();
				highSwitch = !highSwitch;
				attackTriggers [2].SetActive (false);//The HitColliders on the Hands
				attackTriggers [3].SetActive (false);
			}
			else
			{
				anim.SetTrigger ("HighAttack2");
				R_Hand_Effect ();
				highSwitch = !highSwitch;
				attackTriggers [2].SetActive (false);//The HitColliders on the Hands
				attackTriggers [3].SetActive (false);
			}

		}

	}

//	void Dodge ()
//	{
//		print ("Dodge");
//	}

	//Ranged Attacks
	void RangedLowAttack()
	{
		if (BoteManager.onBote == true)
		{
			if (projectileCounter < 1)
			{
				projectileCounter = 1;
				if (this.gameObject.tag == "Player_One")
				{
					FireProjectile (1, 1);
					anim.SetTrigger ("RangedAttack");
				}
				else if (this.gameObject.tag == "Player_Two")
				{
					FireProjectile (2, 1);
					anim.SetTrigger ("RangedAttack");


				}


			}

		}
		else
		{
			projectileCounter = 0;
		}
	}

	void RangedMedAttack()
	{
		if (BoteManager.onBote == true)
		{
			//this.gameObject
			if (projectileCounter < 1)
			{
				projectileCounter = 1;

				if (this.gameObject.tag == "Player_One")
				{
					FireProjectile (1, 2);
					anim.SetTrigger ("RangedAttack");

				}
				else if (this.gameObject.tag == "Player_Two")
				{
					FireProjectile (2, 2);
					anim.SetTrigger ("RangedAttack");

				}

			}
		}
		else
		{
			projectileCounter = 0;
		}
	}

	void RangedHighAttack()
	{
		if (BoteManager.onBote == true) 
		{
			if (projectileCounter < 1 ) 
			{
				projectileCounter = 1;
				//FireProjectile


				if (this.gameObject.tag == "Player_One") 
				{
					FireProjectile (1, 3);
					anim.SetTrigger ("RangedAttack");

				} 

				else if (this.gameObject.tag == "Player_Two") 
				{
					FireProjectile (2, 3);
					anim.SetTrigger ("RangedAttack");

				}

			}
		}
		else
		{
			projectileCounter = 0;
		}
	}

//	void Block(bool block)
//	{
//		if (block)
//		{
//			anim.SetBool ("Block", true);
//		}
//		else
//		{
//			anim.SetBool ("Block", false);
//		}
//	}


	void ChainWindowStart()
	{
		
		window = true;
		//anim.SetBool ("ButtonPress", false);
		//if (inputM.Equals(null))
		//{
		if (attack)
		{
			print ("Subscribe");
			Subscribe ();
		}
		attack = false;
		//}
	}

	void ChainWindowStop()
	{
		window = false;
		if (!attack)
		{
			print ("button press false");
			anim.SetBool ("ButtonPress", false);

			attackTriggers [0].SetActive (true);//The HitColliders on the Feet
			attackTriggers [1].SetActive (true);
			attackTriggers [2].SetActive (true);//The HitColliders on the Hands
			attackTriggers [3].SetActive (true);
			//subCt = 0;
			//print ("setting buttonpress false");
		}
		else if (attack)
		{
			//subCt++;
			anim.SetBool ("ButtonPress", true);
			attackTriggers [0].SetActive (true);//The HitColliders on the Feet
			attackTriggers [1].SetActive (true);
			attackTriggers [2].SetActive (true);//The HitColliders on the Hands
			attackTriggers [3].SetActive (true);

			//attack = false;
			//print ("setting button press two");
		}
		else
		{
			print ("default");
		}
	}

	//
//	void L_Hand_Effect()
//	{
//		L_Hand_Trail.SetActive (true);
//	}

	void L_Hand_Effect()
	{
		L_Hand_Trail.SetActive (true);
	}

	void R_Hand_Effect()
	{
		R_Hand_Trail.SetActive (true);
	}

//	void L_Foot_Effect()
//	{
//		L_Foot_Trail.SetActive (true);
//	}

	void R_Foot_Effect()
	{
		R_Foot_Trail.SetActive (true);
	}



	void P1_EndAllMeleeFX()
	{
		R_Hand_Trail.SetActive (false);
		L_Hand_Trail.SetActive (false);
//		L_Foot_Trail.SetActive (false);
		R_Foot_Trail.SetActive (false);
	}




	//


	void Subscribe()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A += LowAttack;
			InputManager.P1_X += MedAttack;
			InputManager.P1_Y += HighAttack;
			//InputManager.P1_B += Dodge;
			InputManager.P1_RangedA += RangedLowAttack;
			InputManager.P1_RangedX += RangedMedAttack;
			InputManager.P1_RangedY += RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A += LowAttack;
			InputManager.P2_X += MedAttack;
			InputManager.P2_Y += HighAttack;
			//InputManager.P2_B += Dodge;
			InputManager.P2_RangedA += RangedLowAttack;
			InputManager.P2_RangedX += RangedMedAttack;
			InputManager.P2_RangedY += RangedHighAttack;
		}
	}

	void UnSubscribe()
	{
		if (this.gameObject.tag == "Player_One") 
		{
			InputManager.P1_A -= LowAttack;
			InputManager.P1_X -= MedAttack;
			InputManager.P1_Y -= HighAttack;
			//InputManager.P1_B -= Dodge;
			InputManager.P1_RangedA -= RangedLowAttack;
			InputManager.P1_RangedX -= RangedMedAttack;
			InputManager.P1_RangedY -= RangedHighAttack;
		} 

		else if (this.gameObject.tag == "Player_Two") 
		{
			InputManager.P2_A -= LowAttack;
			InputManager.P2_X -= MedAttack;
			InputManager.P2_Y -= HighAttack;
			//InputManager.P2_B -= Dodge;
			InputManager.P2_RangedA -= RangedLowAttack;
			InputManager.P2_RangedX -= RangedMedAttack;
			InputManager.P2_RangedY -= RangedHighAttack;
		}
	}

	void AttackCheck()
	{
		if (window)
		{
			
			if (!inputM.Equals (null))
			{

				attack = true;
				UnSubscribe ();
			}
		}
		else
		{
			attack = false;
		}
	}

	void PlayerDirection()
	{

		float result1 = otherPlayer.transform.position.x - this.transform.position.x;
		float result2 = this.transform.position.x - otherPlayer.transform.position.x;

		if (this.gameObject.tag == "Player_One")
		{
			if (result1 < 0)
			{
				//direction = right
				direction = -1;
			}
			if (result1 > 0)
			{
				direction = 1;
			}
		}
		else if (this.gameObject.tag == "Player_Two")
		{
			if (result2 < 0)
			{
				//direction = right
				direction = -1;
			}
			if (result2 > 0)
			{
				direction = 1;
			}
		}
	}

	void FireProjectile(int playerNum,int projectileType)
	{
		print (playerNum+" "+projectileType);
		GameObject projectileHandler;
		Rigidbody tempRigidBody;
		PlayerDirection ();

		if (playerNum == 1)
		{
			switch (projectileType)
			{
			case 1:

				if (direction == 1) {
					projectileHandler = Instantiate (projectileLV2, p1SpawnPointL.transform.position, p1SpawnPointL.transform.rotation) as GameObject;
					projectileHandler.name = "Low";
					Lists.p1aprojectilelist.Add (projectileHandler);
					tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
					tempRigidBody.velocity = new Vector2 (projectileSpeedLow * direction, projectileLowUp);
				} 
				else 
				{
					projectileHandler = Instantiate (projectileL, p1SpawnPointL.transform.position, p1SpawnPointL.transform.rotation) as GameObject;
					projectileHandler.name = "Low";
					Lists.p1aprojectilelist.Add (projectileHandler);

					tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
					tempRigidBody.velocity = new Vector2 (projectileSpeedLow * direction, projectileLowUp);
				}

				//tempRigidBody.velocity = transform.forward * projectileSpeedLow;
				break;
			case 2:
				projectileHandler = Instantiate (projectileM, p1SpawnPointM.transform.position, p1SpawnPointM.transform.rotation) as GameObject;
				projectileHandler.name = "Mid";
				Lists.p1bprojectilelist.Add (projectileHandler);

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedMed*direction, projectileMedUp);
				//tempRigidBody.velocity = transform.forward * projectileSpeedMed;
				break;
			case 3:
				projectileHandler = Instantiate (projectileH, p1SpawnPointH.transform.position, p1SpawnPointH.transform.rotation) as GameObject;
				projectileHandler.name = "High";
				Lists.p1cprojectilelist.Add (projectileHandler);

				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (projectileSpeedHigh*direction, projectileHighUp);
				//tempRigidBody.velocity = transform.forwardprojectileSpeedHigh, projectileHighUp, 0f);
				break;
			default :

				projectileHandler = null;
				break;
			}




			//projectileHandler.name = "High";
		}
		else if (playerNum == 2)
		{



			switch (projectileType)
			{
			case 1:
				//if (direction == 1) {

					projectileHandler = Instantiate (projectileL, p2SpawnPointL.transform.position, p2SpawnPointL.transform.rotation) as GameObject;
					projectileHandler.name = "Low";
					Lists.p2aprojectilelist.Add (projectileHandler);
					tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
					tempRigidBody.velocity = new Vector2 (-projectileSpeedLow * direction, projectileLowUp);
				//} else {
//					projectileHandler = Instantiate (projectileLV2, p2SpawnPointL.transform.position, p2SpawnPointL.transform.rotation) as GameObject;
//					projectileHandler.name = "Low";
//					Lists.p2aprojectilelist.Add (projectileHandler);
//					tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
//					tempRigidBody.velocity = new Vector2 (projectileSpeedLow * direction, projectileLowUp);
//				}
				break;
			case 2:
				projectileHandler = Instantiate (projectileM, p2SpawnPointM.transform.position, p2SpawnPointM.transform.rotation) as GameObject;
				projectileHandler.name = "Mid";
				Lists.p2bprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedMed*direction, projectileMedUp);
				break;
			case 3:
				projectileHandler = Instantiate (projectileH, p2SpawnPointH.transform.position, p2SpawnPointH.transform.rotation) as GameObject;
				projectileHandler.name = "High";
				Lists.p2cprojectilelist.Add (projectileHandler);


				tempRigidBody = projectileHandler.GetComponent<Rigidbody> ();
				tempRigidBody.velocity = new Vector2 (-projectileSpeedHigh*direction, projectileHighUp);
				break;
			default :

				projectileHandler = null;
				break;
			}



		}



	}
//	void TransitionFalse()
//	{
//		anim.SetBool ("Transition", false);
//	}

//	void ChainWindowStart()
//	{
//		//print("set chain Window true");
//		anim.SetBool ("Chain", false);
//		anim.SetBool ("ChainWindow", true);
//
//	}
//
//	void ChainWindowStop()
//	{
//		print("set chain Window false");
//		anim.SetBool ("ChainWindow", false);
//		anim.SetBool ("Chain", false);
//	}
//
//	void ChainCheck()
//	{
//		print (anim.GetBool ("ChainWindow"));
//		if (anim.GetBool("ChainWindow"))
//		{
//			if (Input.GetButtonDown ("X360_A") && !anim.GetBool ("Chain") || Input.GetButtonDown ("X360_X") && !anim.GetBool ("Chain") || Input.GetButtonDown ("X360_Y") && !anim.GetBool ("Chain"))
//			{
//				print ("set chain true");
//				anim.SetBool ("Chain", true);
//				anim.SetBool ("ChainWindow", false);
//			}
//			else
//			{
//				anim.SetBool ("Chain", false);
//			}
//
//
//		}
//		else
//		{
//			print("set chain false");
//			anim.SetBool ("Chain", false);
//		}
//
//	}
//
//	void ResetAttack()
//	{
//		attackCount = 0;
//	}

}
