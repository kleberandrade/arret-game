using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class CreditsDataEditor :  EditorWindow
{
	public CreditsData creditsData;

	private Vector2 m_ScrollPosition;

	[MenuItem ("Utility/Credits")]
	static void Init()
	{
		EditorWindow.GetWindow (typeof(CreditsDataEditor), false, "Credits").Show ();
	}

	void OnGUI()
	{
		m_ScrollPosition = EditorGUILayout.BeginScrollView (m_ScrollPosition, false, false);
		GUILayout.BeginVertical ();

		SerializedObject serializedObject = new SerializedObject (this);
		SerializedProperty serializedProperty = serializedObject.FindProperty ("creditsData");
		EditorGUILayout.PropertyField (serializedProperty, true);

		serializedObject.ApplyModifiedProperties ();

		GUILayout.EndVertical ();
		EditorGUILayout.EndScrollView ();

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Load"))
		{
			LoadGameData();
		}

		if (GUILayout.Button ("Save"))
		{
			SaveGameData();
		}

		GUILayout.EndHorizontal ();
	}

	private void LoadGameData()
	{
		string filePath = Application.dataPath + CreditsPath.creditsDataProjectFilePath;

		if (File.Exists (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);
			creditsData = JsonUtility.FromJson<CreditsData> (dataAsJson);
		} else 
		{
			creditsData = new CreditsData();
		}
	}

	private void SaveGameData()
	{
		string dataAsJson = JsonUtility.ToJson (creditsData);
		string filePath = Application.dataPath + CreditsPath.creditsDataProjectFilePath;
		File.WriteAllText (filePath, dataAsJson);
	}
}