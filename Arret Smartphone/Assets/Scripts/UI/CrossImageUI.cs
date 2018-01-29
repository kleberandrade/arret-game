using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossImageUI : MonoBehaviour
{
	[SerializeField]
	private Sprite[] m_Sprites = null;

	[SerializeField]
	[Range(0.0f, 20.0f)]
	private float m_TimeToChangeSprite = 5.0f;

	[SerializeField]
	[Range(0.0f, 1.0f)]
	private float m_TimeToCross = 0.6f;

	private Image[] m_images = null;

	private int m_currentImageIndex = 0;

	private int m_currentSpriteIndex = 0;

	private void Start ()
	{
		m_images = GetComponentsInChildren<Image>();

		m_currentSpriteIndex = Random.Range(0, m_Sprites.Length);
		m_images[m_currentImageIndex].sprite = m_Sprites[m_currentSpriteIndex];

		m_images[m_currentImageIndex].CrossFadeAlpha(1.0f, 0.0f, false);
		m_images[1 - m_currentImageIndex].CrossFadeAlpha(0.0f, 0.0f, false);

		InvokeRepeating("ChangeImage", m_TimeToChangeSprite, m_TimeToChangeSprite);
	}

	private int NextSpriteByIndex()
	{
		int nextIndex = m_currentSpriteIndex;
		while (nextIndex == m_currentSpriteIndex) {
			nextIndex = Random.Range(0, m_Sprites.Length);
		}

		return nextIndex;
	}

	private void ChangeImage()
	{
		m_currentSpriteIndex = NextSpriteByIndex();
		m_images[1 - m_currentImageIndex].sprite = m_Sprites[m_currentSpriteIndex];

		m_images[m_currentImageIndex].CrossFadeAlpha(0.0f, m_TimeToCross, false);
		m_images[1 - m_currentImageIndex].CrossFadeAlpha(1.0f, m_TimeToCross, false);

		m_currentImageIndex = 1 - m_currentImageIndex;
	}
}
