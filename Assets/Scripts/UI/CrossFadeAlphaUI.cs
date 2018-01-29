using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CrossFadeAlphaUI : MonoBehaviour
{
	[SerializeField]
	public enum FadeType
	{
		Out = 0,
		In
	};

	[SerializeField]
	private FadeType m_FadeType = FadeType.In;

	[SerializeField]
	private bool m_FadeOnStart = true;

	[SerializeField]
	private float m_FadeTime = 1.0f;

	public float FadeTime 
	{
		get { return m_FadeTime; }
	}

	public bool FadeOnStart 
	{
		get { return m_FadeOnStart; }
		set { m_FadeOnStart = value; }
	}

	public FadeType FadeInOut
	{
		get { return m_FadeType; }
		set { m_FadeType = value; }
	}

	[SerializeField]
	private AnimationCurve m_AlphaCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 1));

	private CanvasGroup m_CanvasGroup;

	private void Awake()
	{
		m_CanvasGroup = GetComponent<CanvasGroup>();
	}

	private void Start()
	{
		m_AlphaCurve.preWrapMode = WrapMode.Clamp;
		m_AlphaCurve.postWrapMode = WrapMode.Clamp;

		m_CanvasGroup.alpha = (int)m_FadeType;

		if (m_FadeOnStart)
			Fade ();
	}

	public void Fade()
	{
		StartCoroutine (ExecuteFade());
	}

	public IEnumerator ExecuteFade ()
	{
		float elapsedTime = 0.0f;
		float time = 0.0f;

		while (time < 1.0f) 
		{
			time = Mathf.Clamp01(m_AlphaCurve.Evaluate(elapsedTime / m_FadeTime));
			m_CanvasGroup.alpha = Mathf.Lerp((int)m_FadeType, 1 - (int)m_FadeType, time);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		m_FadeType = (FadeType)(1 - (int)m_FadeType);
		m_CanvasGroup.alpha = (int)m_FadeType;

		yield return null;
	}
}
