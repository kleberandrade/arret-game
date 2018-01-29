using System.Collections;
using UnityEngine;

public class CreditsCardController : MonoBehaviour 
{
	[SerializeField]
	private GameObject m_CreditsCardPrefab;

	private CreditsData m_CreditsData;

	private RectTransform m_Transform;

	private void Start () 
	{
		m_Transform = GetComponent<RectTransform> ();
		LoadGameData ();
		CreateCreditsCard ();
	}

	private void LoadGameData()
	{
		string filePath = "Credits/credits_data";
		TextAsset text = Resources.Load<TextAsset> (filePath);
		if (text != null) {	
			string dataAsJson = text.ToString();
			m_CreditsData = JsonUtility.FromJson<CreditsData> (dataAsJson);
		} 
		else 
		{
			m_CreditsData = new CreditsData();
		}
	}

	private void CreateCreditsCard()
	{
		StartCoroutine ("FillCard");
	}

	private IEnumerator FillCard()
	{
		foreach (CreditsProfessionalData data in m_CreditsData.credits) 
		{
			GameObject cardGO = Instantiate (m_CreditsCardPrefab);
			cardGO.transform.localScale = Vector3.one;
			cardGO.transform.SetParent(m_Transform, false);

			CreditsCard card = cardGO.GetComponent<CreditsCard> ();
			card.SetCreditsData (data);

			yield return null;
		}
	}
}
