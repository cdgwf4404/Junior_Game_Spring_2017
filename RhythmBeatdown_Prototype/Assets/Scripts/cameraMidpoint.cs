using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cameraMidpoint : MonoBehaviour {

	public float cameraZOffset, cameraYOffeset, cameraRotate, speed;
	private float distance, midpoint, xDistance;
	private Vector3 cameraPosition;
	public GameObject player1, player2;
	public Slider crowdMeter;

	void Start () 
	{
		//Set the y position and x rotation here
		transform.position = new Vector3 ( transform.position.x, cameraYOffeset, transform.position.z);
		transform.eulerAngles = new Vector3 (cameraRotate, transform.rotation.y, transform.rotation.z);
	}

	void FixedUpdate () 
	{
		if (!WinConditions.gameOver) {
			//Midpoint equals the midpoint between the two players - Distance is the distance between the players and will be used for cameraZPosition
			midpoint = player1.transform.position.x + (player2.transform.position.x - player1.transform.position.x) / 2; 
			distance = Mathf.Abs (Vector3.Distance (player1.transform.position, player2.transform.position));

			//Set cameraPosition according to the variables above and lerp between  those positions
			cameraPosition = new Vector3 (midpoint, transform.position.y, Mathf.Clamp (-distance + cameraZOffset, -24, -11));
			transform.position = Vector3.Lerp (transform.position, cameraPosition, speed * Time.deltaTime);
		} else 
		{
			if (crowdMeter.value < 50) 
			{
				Vector3 currentPos = this.transform.position; 
				this.transform.position = Vector3.Lerp (currentPos, new Vector3(player1.transform.position.x, player1.transform.position.y + 3f, player1.transform.position.z - 6f), speed * Time.deltaTime);
			} 
			else if (crowdMeter.value > 50) 
			{
				Vector3 currentPos = this.transform.position; 
				this.transform.position = Vector3.Lerp (currentPos, new Vector3(player2.transform.position.x, player2.transform.position.y + 3f, player2.transform.position.z - 6f), speed * Time.deltaTime);
			} 
			else 
			{
				print ("Draw");	
			}
		}
	}
}
