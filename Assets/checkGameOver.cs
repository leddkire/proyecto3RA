﻿using UnityEngine;
using System.Collections;

public class checkGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -10) {
			Application.LoadLevel("gameStart");
		}
	}
}
