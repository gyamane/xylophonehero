using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class NoteManager : MonoBehaviour {

	//ABC********************************************************
	//Where the values from the text file will be stored
	private string[] texttoreadABC;
	private string[][] notesanddelaysABC;

	//Data structures holding the notes to spawn and the wait time to spawn them
	private int[] notesABC;
	private float[] delaysABC;

	//Index to use for referencing which note to spawn and when
	private int indexABC = 0;

	private float timerABC = 29 + 11;
	//ODE TO JOY*************************************************
	//Where the values from the text file will be stored
	private string[] texttoreadOdeToJoy;
	private string[][] notesanddelaysOdeToJoy;

	//Data structures holding the notes to spawn and the wait time to spawn them
	private int[] notesOdeToJoy;
	private float[] delaysOdeToJoy;

	//Index to use for referencing which note to spawn and when
	private int indexOdeToJoy = 0;

	private float timerOdeToJoy = 45 + 11;
	//JINGLE BELLS********************************************************
	//Where the values from the text file will be stored
	private string[] texttoreadJingleBells;
	private string[][] notesanddelaysJingleBells;

	//Data structures holding the notes to spawn and the wait time to spawn them
	private int[] notesJingleBells;
	private float[] delaysJingleBells;

	//Index to use for referencing which note to spawn and when
	private int indexJingleBells = 0;

	private float timerJingleBells = 38 + 11;
	//FRER JACQUES********************************************************
	//Where the values from the text file will be stored
	private string[] texttoreadFrereJacques;
	private string[][] notesanddelaysFrereJacques;

	//Data structures holding the notes to spawn and the wait time to spawn them
	private int[] notesFrereJacques;
	private float[] delaysFrereJacques;

	//Index to use for referencing which note to spawn and when
	private int indexFrereJacques = 0;

	private float timerFrereJacques = 21 + 11;
	//**********************************************************************
	private float timerFreePlay = 20;
	//Time to reference when to spawn notes
	private float startTime = 0.0F;

	public GameObject note1;
	public GameObject note2;
	public GameObject note3;
	public GameObject note4;
	public GameObject note5;
	public GameObject note6;
	bool finishedReading;
	public bool songSelected;
	public GameObject text;

	int index;
	private int[] notes;
	private float[] delays;
	private float referenceTime;
	// Use this for initialization
	void Start () {
		finishedReading = false;
		songSelected = false;
		parseABC ();
		parseOdeToJoy ();
		parseJingleBells ();
		parseFrereJacques ();
	}

	// Update is called once per frame
	void Update () {
		if (finishedReading && songSelected && notes != null && index < notes.Length && delays[index] <= (Time.time - referenceTime + 5)) {
			if (notes [index] == 1) {
				Instantiate (note1, new Vector3(.75f, .7f, -20.0f), Quaternion.identity);
			} else if (notes [index] == 2) {
				Instantiate (note2, new Vector3(.45f, .7f, -20.0f), Quaternion.identity);
			} else if (notes [index] == 3) {
				Instantiate (note3, new Vector3(.15f, .7f, -20.0f), Quaternion.identity);
			} else if (notes [index] == 4) {
				Instantiate (note4, new Vector3(-.15f, .7f, -20.0f), Quaternion.identity);
			} else if (notes [index] == 5) {
				Instantiate (note5, new Vector3(-.45f, .7f, -20.0f), Quaternion.identity);
			} else if (notes [index] == 6) {
				Instantiate (note6, new Vector3(-.75f, .7f, -20.0f), Quaternion.identity);
			}
			index += 1;
		}
	}

	public void selectABC(){
		notes = notesABC;
		delays = delaysABC;
		songSelected = true;
		index = 0;
		referenceTime = Time.time;
		StartCoroutine (timer (timerABC, 43));
	}
	public void selectOdeToJoy(){
		print ("notesOdeToJoy == null " + (notesOdeToJoy == null));
		notes = notesOdeToJoy;
		delays = delaysOdeToJoy;
		songSelected = true;
		index = 0;
		referenceTime = Time.time;
		StartCoroutine (timer (timerOdeToJoy, 77));
	}
	public void selectJingleBells(){
		notes = notesJingleBells;
		delays = delaysJingleBells;
		songSelected = true;
		index = 0;
		referenceTime = Time.time;
		StartCoroutine (timer (timerJingleBells, 51));
	}
	public void selectFrereJacques(){
		notes = notesFrereJacques;
		delays = delaysFrereJacques;
		songSelected = true;
		index = 0;
		referenceTime = Time.time;
		StartCoroutine (timer (timerFrereJacques, 32));
	}
	public void selectFreePlay(){
		StartCoroutine (timer (timerFreePlay, 32));
	}
	IEnumerator timer(float time, int notes){
		yield return new WaitForSeconds (time);
		Message message = text.GetComponent<Message> ();
		message.displayFinal (notes);
		yield return new WaitForSeconds (5);
		songSelected = false;
		message.score = 0;
		message.displayInstructions ();
	}

	public void parseABC(){
		var path = Path.Combine (Application.dataPath, "abc.txt");
		texttoreadABC = File.ReadAllLines (path);
		notesanddelaysABC = new string[texttoreadABC.Length][];
		notesABC = new int[texttoreadABC.Length];
		delaysABC = new float[texttoreadABC.Length];

		//separating notes and delays into separate arrays
		for (int i = 0; i < texttoreadABC.Length; i++) {
			notesanddelaysABC[i] = texttoreadABC[i].Split (new string[] { "," }, StringSplitOptions.None);

			//setting the note and delay arrays
			try
			{
				notesABC[i] = Convert.ToInt32(notesanddelaysABC [i] [0]);
				delaysABC [i] = float.Parse(notesanddelaysABC [i] [1]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0} Exception caught.", ex);
			}
		}
		finishedReading = true;
	}
		
	public void parseOdeToJoy(){
		var path = Path.Combine (Application.dataPath, "OdeToJoy.txt");
		texttoreadOdeToJoy = File.ReadAllLines (path);
		notesanddelaysOdeToJoy = new string[texttoreadOdeToJoy.Length][];
		notesOdeToJoy = new int[texttoreadOdeToJoy.Length];
		delaysOdeToJoy = new float[texttoreadOdeToJoy.Length];

		//separating notes and delays into separate arrays
		for (int i = 0; i < texttoreadOdeToJoy.Length; i++) {
			notesanddelaysOdeToJoy[i] = texttoreadOdeToJoy[i].Split (new string[] { "," }, StringSplitOptions.None);

			//setting the note and delay arrays
			try
			{
				notesOdeToJoy[i] = Convert.ToInt32(notesanddelaysOdeToJoy [i] [0]);
				delaysOdeToJoy [i] = float.Parse(notesanddelaysOdeToJoy [i] [1]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0} Exception caught.", ex);
			}
		}
		finishedReading = true;
	}
	public void parseJingleBells(){
		var path = Path.Combine (Application.dataPath, "JingleBells.txt");
		texttoreadJingleBells = File.ReadAllLines (path);
		notesanddelaysJingleBells = new string[texttoreadJingleBells.Length][];
		notesJingleBells = new int[texttoreadJingleBells.Length];
		delaysJingleBells = new float[texttoreadJingleBells.Length];

		//separating notes and delays into separate arrays
		for (int i = 0; i < texttoreadJingleBells.Length; i++) {
			notesanddelaysJingleBells[i] = texttoreadJingleBells[i].Split (new string[] { "," }, StringSplitOptions.None);

			//setting the note and delay arrays
			try
			{
				notesJingleBells[i] = Convert.ToInt32(notesanddelaysJingleBells [i] [0]);
				delaysJingleBells [i] = float.Parse(notesanddelaysJingleBells [i] [1]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0} Exception caught.", ex);
			}
		}
		finishedReading = true;
	}
	public void parseFrereJacques(){
		var path = Path.Combine (Application.dataPath, "FrereJacques.txt");
		texttoreadFrereJacques = File.ReadAllLines (path);
		notesanddelaysFrereJacques = new string[texttoreadFrereJacques.Length][];
		notesFrereJacques = new int[texttoreadFrereJacques.Length];
		delaysFrereJacques = new float[texttoreadFrereJacques.Length];

		//separating notes and delays into separate arrays
		for (int i = 0; i < texttoreadFrereJacques.Length; i++) {
			notesanddelaysFrereJacques[i] = texttoreadFrereJacques[i].Split (new string[] { "," }, StringSplitOptions.None);

			//setting the note and delay arrays
			try
			{
				notesFrereJacques[i] = Convert.ToInt32(notesanddelaysFrereJacques [i] [0]);
				delaysFrereJacques [i] = float.Parse(notesanddelaysFrereJacques [i] [1]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0} Exception caught.", ex);
			}
		}
		finishedReading = true;
	}
}