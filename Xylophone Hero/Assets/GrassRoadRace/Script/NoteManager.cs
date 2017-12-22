using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class NoteManager : MonoBehaviour {
	//Where the values from the text file will be stored
	private string[] texttoread;
	private string[][] notesanddelays;

	//Data structures holding the notes to spawn and the wait time to spawn them
	private int[] notes;
	private float[] delays;

	//Index to use for referencing which note to spawn and when
 	private int index = 0;

	//Time to reference when to spawn notes
	public float startTime = 0.0F;

	// Use this for initialization
	void Start () {
		//intializing data structures to hold notes and arrays
		texttoread = Read ();
		notesanddelays = new string[texttoread.Length][];
		notes = new int[texttoread.Length];
		delays = new float[texttoread.Length];

		//separating notes and delays into separate arrays
		for (int i = 0; i < texttoread.Length; i++) {
			notesanddelays[i] = texttoread[i].Split (new string[] { "," }, StringSplitOptions.None);

			//setting the note and delay arrays
			try
			{
				notes[i] = Convert.ToInt32(notesanddelays [i] [0]);
				delays [i] = float.Parse(notesanddelays [i] [1]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("{0} Exception caught.", ex);
			}
		}

	}

	// Update is called once per frame
	void Update () {
		if (delays[index] <= Time.time) {
			Debug.Log (delays[index]);
			index += 1;
		}
	}

	//Reading a text file containing a song (the notes and the time delays corresponding to spawn times)
	private string[] Read()
	{
		var path = Path.Combine (Application.dataPath, "abc.txt");
		var toreturn = File.ReadAllLines (path);
		return toreturn;
	}
}
