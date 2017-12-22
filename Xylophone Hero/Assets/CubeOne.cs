using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOne : MonoBehaviour {

	private AudioSource audiosource;
	bool rmovingDown;
	bool lmovingDown;
	public GameObject rmallet;
	public GameObject lmallet;
	public GameObject NoteManager;
	Vector3 rPosition;
	Vector3 lPosition;
	bool noteActive;
	public GameObject text;
	//public GameObject Note;
	public Material white;
	private bool malletdown;



	// Use this for initialization
	void Start () {
		audiosource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (rmallet.transform.position != rPosition) {
			if (rmallet.transform.position.y < rPosition.y) {
				rmovingDown = true;
			} else {
				rmovingDown = false;
			}
			rPosition = rmallet.transform.position;
		}

		if (lmallet.transform.position != lPosition) {
			if (lmallet.transform.position.y < lPosition.y) {
				lmovingDown = true;
			} else {
				lmovingDown = false;
			}
			lPosition = lmallet.transform.position;
		}
	}
		
	void OnTriggerExit(Collider col){
		if (col.gameObject) {
			if (col.CompareTag ("note")) {
				noteActive = false;
			}
			if (col.CompareTag ("rightmallet") || col.CompareTag ("leftmallet")) {
				malletdown = false;
			}
		}
	}
	void OnTriggerStay(Collider col){
		if (col.gameObject) {
			if (col.CompareTag ("note") && malletdown) {
				col.GetComponent<MeshRenderer> ().material = white;
			}
		}
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject) {
			if (col.CompareTag ("note")) {
				noteActive = true;
			}
		}
		if (col.gameObject) {
			if ((col.CompareTag ("rightmallet") && rmovingDown) || (col.CompareTag ("leftmallet") && lmovingDown)) {
				NoteManager noteManager = NoteManager.GetComponent<NoteManager> ();
				if (noteManager.songSelected == false) {
					if (this.CompareTag ("pink")) {
						noteManager.selectABC();
						noteManager.songSelected = true;
						Message message = text.GetComponent<Message> ();
						message.displayScore ();
					} else if (this.CompareTag ("orange")) {
						noteManager.selectOdeToJoy();
						noteManager.songSelected = true;
						Message message = text.GetComponent<Message> ();
						message.displayScore ();
					} else if (this.CompareTag ("yellow")) {
						noteManager.selectJingleBells ();
						noteManager.songSelected = true;
						Message message = text.GetComponent<Message> ();
						message.displayScore ();
					} else if (this.CompareTag ("green")) {
						noteManager.selectFrereJacques ();
						noteManager.songSelected = true;
						Message message = text.GetComponent<Message> ();
						message.displayScore ();
					} else if (this.CompareTag ("blue")) {
						noteManager.selectFreePlay ();
						noteManager.songSelected = true;
						Message message = text.GetComponent<Message> ();
						message.Hide ();
					}
				}
				audiosource.PlayOneShot (audiosource.clip);
				malletdown = true;
				if (noteActive) {
					Message message = text.GetComponent<Message> ();
					message.score++;
					message.displayScore ();
					noteActive = false;

				}
			}
		}
	}
}
