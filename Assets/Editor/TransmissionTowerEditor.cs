using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TransmissionTower))]
public class TransmissionTowerEditor : Editor 
{
	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		GUILayout.Space (20);

		TransmissionTower tower = (TransmissionTower)target;
		GUI.backgroundColor = Color.red;
        GUI.contentColor = Color.white;
		if (GUILayout.Button ("Destroy")) 
		{
			tower.Destroy ();
		}
	}

}
