using UnityEngine;
using System.Collections;

public class SingletonSystem<T> : MonoBehaviour
	where T : SingletonSystem<T>
{
	protected static T _Instance;


	// Awake
	void Awake()
	{
		if( _Instance == null ){
			_Instance = (T)this;
			DontDestroyOnLoad( gameObject );
		}else{
			Destroy( gameObject );
		}
	}
}
