using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour 
{
	[SerializeField]
	private Vector3 m_Range = Vector3.zero;

	[SerializeField]
	private float m_Time = 1.0f;

	[SerializeField]
	private AnimationCurve m_XCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

	[SerializeField]
	private AnimationCurve m_YCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

	[SerializeField]
	private AnimationCurve m_ZCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

	private float m_ElapsedTime;

	private RectTransform m_Transform;

	private Vector3 m_HomePosition;
		
	private void Awake()
	{
		m_Transform = GetComponent<RectTransform>();
	}

	private void OnEnable()
	{
		m_HomePosition = m_Transform.anchoredPosition3D;

		Execute ();
	}

	private void OnDisable()
	{
		m_Transform.anchoredPosition3D = m_HomePosition;
	}

	private void Execute()
	{
		m_Transform.anchoredPosition3D = m_HomePosition + m_Range;
		StartCoroutine("Animate");
	}

	private IEnumerator Animate()
	{
		yield return null;

		Vector3 from = m_HomePosition + m_Range;
		Vector3 to = m_HomePosition;

		yield return StartCoroutine(Move(from, to));
	}
	
	private IEnumerator Move(Vector3 from, Vector3 to)
	{
		m_ElapsedTime = 0.0f;

		while (m_ElapsedTime / m_Time < 1.0f)
		{
			m_ElapsedTime += Time.deltaTime;

			float time = Mathf.Clamp01(m_ElapsedTime / m_Time);
			float x = Mathf.Lerp(from.x, to.x, m_XCurve.Evaluate(time));
			float y = Mathf.Lerp(from.y, to.y, m_YCurve.Evaluate(time));
			float z = Mathf.Lerp(from.z, to.z, m_ZCurve.Evaluate(time));

			m_Transform.anchoredPosition3D = new Vector3(x, y, z);

			yield return null;
		}

		m_Transform.anchoredPosition3D = to;
	}

	public Vector3 Range
	{
		get { return m_Range; } 
		set { m_Range = value; }
	}
}
