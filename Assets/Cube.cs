﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision)
	{
		//if (collision.gameObject.tag == "Player") {
		//	this.transform.position += new Vector3 (0, 0, 1);
		//}
	}
}