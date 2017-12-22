using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
	//private double speed = .05;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (Vector3.forward * speed);
		Vector3 pos = transform.position;
		pos.z = transform.position.z + .02f;
		transform.position = pos;
	}
}
