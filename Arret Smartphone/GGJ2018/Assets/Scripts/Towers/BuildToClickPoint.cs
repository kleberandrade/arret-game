using UnityEngine;
using UnityEngine.UI;

public class BuildToClickPoint : MonoBehaviour 
{
	public LayerMask m_GroundLayer;

	public LayerMask m_TowerLayer;

	public Color m_Color = Color.white;

	public Vector3 m_Offset = Vector3.up;

    public float m_CooldownTime = 5.0f;

    private float m_CurrentCooldownTime;

    private float m_NextCooldownTime;

    private bool m_CanBuilder = false;

	public float m_MinDistanceToBuild = 2.0f;

    public Slider m_CooldownSlider;

    private void Start()
    {
        m_NextCooldownTime = Time.time + m_CooldownTime;
        m_CooldownSlider.minValue = 0;
        m_CooldownSlider.maxValue = 1;
        m_CooldownSlider.value = 0.0f;
    }

    private void Update() 
	{
        m_CurrentCooldownTime = Time.time;
        m_CanBuilder = m_CurrentCooldownTime >= m_NextCooldownTime;

        float cooldown = 1.0f - (m_NextCooldownTime - m_CurrentCooldownTime) / m_CooldownTime;
        m_CooldownSlider.value = cooldown;

        if (!m_CanBuilder)
            return;

		if (Input.GetMouseButtonDown(0)) 
		{
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000.0f, m_GroundLayer)) {

				Collider[] colliders = Physics.OverlapSphere (hit.point, m_MinDistanceToBuild, m_TowerLayer);
				if (colliders.Length == 0)
					BuildManager.Instance.GetTower (hit.point + m_Offset, m_Color);
			}

            m_CanBuilder = false;
            m_NextCooldownTime = Time.time + m_CooldownTime;
		}
	}
}
