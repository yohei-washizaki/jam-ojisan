﻿using UnityEngine;
using System.Collections;

public class GameFlow : MonoBehaviour
{
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if( GUILayout.Button("Clear") ){
			Application.LoadLevel( "GameOver" );
		}
	}
}
