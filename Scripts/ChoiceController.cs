﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel ("Intro");
		} else if (Input.GetKeyDown ("q")) {
			Application.Quit ();
		}
	}
}
