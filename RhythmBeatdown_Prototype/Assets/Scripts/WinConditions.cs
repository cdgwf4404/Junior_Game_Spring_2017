using UnityEngine;
using System.Collections;
using SonicBloom.Koreo.Players;
using UnityEngine.UI;

public class WinConditions : MonoBehaviour {

	public MultiMusicPlayer MusicPlayer;
	public Slider crowdSlider;
	public Text p1Txt;
	public Text p2Txt;
	public static bool gameOver = false;
	public Button quitBtn;
	// Use this for initialization
	void Start () {
		p1Txt.enabled = false;
		p2Txt.enabled = false;
		quitBtn.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//See if we can move this later
		if (!MusicPlayer.IsPlaying) 
		{
			gameOver = true;
			if (crowdSlider.value > 75) 
			{
				print ("P2 Wins");
				p2Txt.enabled = true;
				quitBtn.gameObject.SetActive (true);
			}
			else if (crowdSlider.value < 25) 
			{
				print ("P1 Wins");
				p1Txt.enabled = true;
				quitBtn.gameObject.SetActive (true);
			}
		}

	}
}
