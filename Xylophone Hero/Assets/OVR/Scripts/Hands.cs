using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {

	public OVRInput.Controller controller;
	public GameObject text;
	//public GameObject NoteManager;
	private float indexTriggerState = 0;
	private float handTriggerState = 0;
	private float oldIndexTriggerState = 0;
	private bool holdingMallet = false;
	private GameObject mallet = null;

	public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
	public Vector3 holdRotation = new Vector3(0, 180, 0);
	
	// Update is called once per frame
	void Update () {
		oldIndexTriggerState = indexTriggerState;
		indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
		handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("rightmallet") || other.CompareTag("leftmallet")) {
			if (handTriggerState > 0.9f && !holdingMallet) {
				Grab (other.gameObject);
				Message message = text.GetComponent<Message> ();
				message.displayInstructions ();
				//NoteManager noteManager = NoteManager.GetComponent<NoteManager> ();
				//noteManager.playOdeToJoy ();
			}
		}
	}

	void Grab(GameObject obj) {
		holdingMallet = true;
		mallet = obj;

		mallet.transform.parent = transform;	
		mallet.transform.localPosition = holdPosition;
		mallet.transform.localEulerAngles = holdRotation;
		mallet.GetComponent<Rigidbody>().isKinematic = true;

	}


}
