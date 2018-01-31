using System.Collections.Generic;
using UnityEngine;

public class TransmissionTower : MonoBehaviour 
{
	public Color m_Color = Color.white;

	[Range(0.0f, 1.0f)]
	public float m_AlphaColor = 0.25f;

	public float m_RayDistance = 5.0f;

	public float m_StartDistance = 1.0f;

	public LayerMask m_Layer;

	public GameObject m_RayLaserPrefab;

    public Renderer m_IconRenderer;

    public Renderer m_ShieldRenderer;

    private List<RayLaser> m_LaserList = new List<RayLaser>();

	private void Start()
	{
		CheckTowersAround ();

        m_IconRenderer.material.SetColor("_Color", m_Color);
        m_IconRenderer.material.SetColor("_EmissionColor", m_Color);
        m_IconRenderer.material.EnableKeyword("_Emission");

        m_ShieldRenderer.material.SetColor("_MainColor", m_Color);
    }

	private void CheckTowersAround()
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, m_RayDistance, m_Layer);
		foreach (Collider collider in colliders) 
		{
			if (collider.transform == transform)
				continue;

			GameObject go = Instantiate (m_RayLaserPrefab, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;

			RayLaser rayLaser = go.GetComponent<RayLaser> ();
			rayLaser.SetEndPoint (collider.transform, m_Color);

			m_LaserList.Add (rayLaser);
		}
	}

	public void Destroy()
	{
		BuildManager.Instance.DestroyTower (transform.position);
		Destroy (gameObject);
	}

	private void OnDrawGizmos() 
	{
		Gizmos.color = ColorExtension.AlphaColor (m_Color, m_AlphaColor);
		Gizmos.DrawSphere(transform.position, m_RayDistance);
	}
}
