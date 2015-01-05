using UnityEngine;
using System.Collections;

public class GameOverFlow : MonoBehaviour
{
	private float _ChangeFlowTimer;


	// Use this for initialization
	void Start ()
	{
		_ChangeFlowTimer = 10.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_ChangeFlowTimer -= Time.deltaTime;
		if( _ChangeFlowTimer <= 0.0f ){
			jumpTitle();
		}
	}

	void OnGUI()
	{
		if( GUILayout.Button("Titleへ") ){
			jumpTitle();
		}		                        
	}

	private void jumpTitle()
	{
		Application.LoadLevel( "Title" );
	}
}
