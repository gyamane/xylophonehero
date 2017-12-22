using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

	Text message;
	public int score;
	// Use this for initialization
	void Start () {
		message = GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	public void Hide() {
		message.text = "";
	}

	public void displayScore(){
		message.text = "Score: " + score;
	}

	public void displayInstructions(){
		message.text = "Hit Red for ABC's \nHit Orange for Ode to Joy\nHit Yellow for Jingle Bells\nHit Green for Frere Jacques\nHit Blue for 20sec Free Play";
	}

	public void displayFinal(int notes){
		message.text = "You hit " + score + " notes!";
	}
}
