using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour 
{
	[SerializeField]
	private Vector3 m_Axis = Vector3.forward;

	[SerializeField]
	private float m_Speed = 200.0f;

	private RectTransform m_Transform;

	private void Start () 
	{
		m_Transform = GetComponent<RectTransform> ();
	}

	private void Update () 
	{
		m_Transform.Rotate (m_Axis * m_Speed * Time.deltaTime);	
	}
}
