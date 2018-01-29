using UnityEngine;
using UnityEngine.UI;

public class CreditsCard : MonoBehaviour 
{
	[SerializeField]
	private Image m_ProfessionalImage;

	[SerializeField]
	private Text m_ProfessionalName;

	[SerializeField]
	private Text m_ProfessionalEmail;

	[SerializeField]
	private Text m_ProfessionalJobs;

	public void SetCreditsData (CreditsProfessionalData data) 
	{
		if (data.name != null && data.name != "") 
		{
			m_ProfessionalName.text = string.Format (data.name);
		}

		if (data.email != null && data.email != "") 
		{
			m_ProfessionalEmail.text = string.Format (data.email);
		}

		if (data.jobs != null && data.jobs != "") 
		{
			m_ProfessionalJobs.text = string.Format (data.jobs);
		}

		if (data.image != null && data.image != "") 
		{
			Sprite sprite  = Resources.Load<Sprite> ("Credits/" + data.image);
			m_ProfessionalImage.sprite = sprite;
		}
	}
		
}
