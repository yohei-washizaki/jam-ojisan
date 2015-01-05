using UnityEngine;
using System.Collections;

public class TitleFlow : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if( GUILayout.Button("Start") ){
			Application.LoadLevel( "Game" );
		}
	}
}
