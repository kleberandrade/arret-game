using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour 
{
	[SerializeField]
	private string m_NextSceneName;

	private bool m_Pressed = false;

	private void Update()
	{
		if (m_Pressed)
			return;

#if UNITY_ANDROID && !UNITY_EDITOR
		if (Input.touchCount > 0)
#else
		if (Input.anyKeyDown) 
#endif
		{
			m_Pressed = true;
			SceneManager.LoadScene (m_NextSceneName);
		}
	}
}
