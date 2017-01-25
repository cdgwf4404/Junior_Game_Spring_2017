using UnityEngine;
using System.Collections;

public class PhysicsLayerTest : MonoBehaviour {

	private GameObject player;
	private Rigidbody rb;
	private CapsuleCollider capCol;
	private float colRadius;

	// Use this for initialization
	void Start () {
		player = this.gameObject;
		rb = player.GetComponent<Rigidbody> ();
		capCol = player.GetComponent<CapsuleCollider> ();
		colRadius = capCol.radius;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player_One" || col.gameObject.tag == "Player_Two")
		{
			ColliderSize ();
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player_One" || col.gameObject.tag == "Player_Two")
		{
			ColliderSize ();
		}
	}

	void ColliderSize()
	{
		//Vector3 localVel = transform.InverseTransformDirection (rb.velocity);
		if(player.gameObject.tag == "Player_One")
		{
			if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Horizontal") > 0.65f)
			{
				//capCol.radius -= 0.25f;
				player.layer = LayerMask.NameToLayer("p1Pass");
				StartCoroutine (ResetCol ());
			}
			 
			//capCol.enabled = false;
				
		}
		else if(player.gameObject.tag == "Player_Two")
		{
			if (Input.GetAxis("Horizontalp2") < -0.65f || Input.GetAxis("Horizontalp2") > 0.65f)
			{
				player.layer = LayerMask.NameToLayer("p2Pass");
				StartCoroutine (ResetCol ());
			}
				//capCol.enabled = false;
				

		}
	}

	IEnumerator ResetCol ()
	{
		yield return new WaitForSeconds (0.25f);

		if (player.gameObject.tag == "Player_One")
		{
			player.layer = LayerMask.NameToLayer ("Player1");
		}
		else if (player.gameObject.tag == "Player_Two")
		{
			player.layer = LayerMask.NameToLayer ("Player2");
		}
	}
}