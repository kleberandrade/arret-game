using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CrossFadeAlphaUI))]
public class PingPongAlphaUI : MonoBehaviour 
{
	private CrossFadeAlphaUI m_Fade;

	private void Awake()
	{
		m_Fade = GetComponent<CrossFadeAlphaUI> ();
	}

	private void Start()
	{
		m_Fade.FadeOnStart = true;
	}

	private void OnEnable () 
	{
		StartCoroutine ("PingPong");
	}

	private IEnumerator PingPong () 
	{
		yield return null;
		while (true) 
		{
			yield return StartCoroutine (m_Fade.ExecuteFade ());
		}
	}
}
