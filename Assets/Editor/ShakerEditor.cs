using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Shaker))]
public class ShakerEditor : Editor {
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector();

		Shaker shaker = (Shaker)target;
		if(GUILayout.Button("Shake"))
		{
			shaker.Shake();
		}
	}
}
