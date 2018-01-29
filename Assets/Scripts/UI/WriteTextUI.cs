using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteTextUI : MonoBehaviour 
{
	private Text m_Text;

	private string m_TextToWrite;

	[SerializeField]
	private float m_LetterTime;

	private void Awake () 
	{
		m_Text = GetComponent<Text> ();
	}

	public void SetText(string text)
	{
		m_TextToWrite = text;
		StartCoroutine ("Writing");
	}

	private IEnumerator Writing()
	{
		m_Text.text = string.Empty;
		for (int i = 0; i < m_TextToWrite.Length; i++)
		{
			m_Text.text = m_TextToWrite.Substring(0, i + 1);
			yield return new WaitForSeconds(m_LetterTime);
		}

		m_Text.text = m_TextToWrite;

		yield return null;
	}
}