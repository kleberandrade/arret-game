using UnityEngine;
using UnityEngine.UI;

using ANET.Networking;

public class BuildToClickPoint : MonoBehaviour 
{
	public LayerMask m_GroundLayer;

	public LayerMask m_TowerLayer;

	public Color m_BlueColor    = Color.white;
    public Color m_RedColor     = Color.white;
    public Color m_Color        = Color.white;

    public Vector3 m_Offset = Vector3.up;

    public float m_CooldownTime = 5.0f;

    private float m_CurrentCooldownTime;

    private float m_NextCooldownTime;

    private bool m_CanBuilder = false;

	public float m_MinDistanceToBuild = 2.0f;

    public Slider m_CooldownSlider;

    public static BuildToClickPoint Instance;

    public void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("BuildManager: existe mais de uma instancia ativa.");
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        m_NextCooldownTime = Time.time + m_CooldownTime;
        if (!m_CooldownSlider)
            return;
        m_CooldownSlider.minValue = 0;
        m_CooldownSlider.maxValue = 1;
        m_CooldownSlider.value = 0.0f;
    }

    private void Update() 
	{
        m_CurrentCooldownTime = Time.time;
        m_CanBuilder = m_CurrentCooldownTime >= m_NextCooldownTime;

        float cooldown = 1.0f - (m_NextCooldownTime - m_CurrentCooldownTime) / m_CooldownTime;
        if (m_CooldownSlider)
            m_CooldownSlider.value = cooldown;

        if (!m_CanBuilder)
            return;

		if (Input.GetMouseButtonDown(0)) 
		{
            if (!Networking.Instance.Host) // So quem nao for o host pode construir pois o host é sempre o VR (q nao constroi xD)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000.0f, m_GroundLayer))
                {
                    Collider[] colliders = Physics.OverlapSphere(hit.point, m_MinDistanceToBuild, m_TowerLayer);
                    if (colliders.Length == 0)
                    {

                        if(Networking.Instance.PlayerColor == "blue")
                        {
                            m_Color = m_BlueColor;
                        }
                        else
                        {
                            m_Color = m_RedColor;
                        }

                        Transform towerTransform = BuildManager.Instance.GetTower(hit.point + m_Offset, m_Color); // Instancia o drone e cata o transform
                        int droneId = towerTransform.GetComponent<TransmissionTower>().DroneId;
                        Networking.Instance.PlaceDrone(droneId, towerTransform.position); // Envia o position (truncado no BuildManager) pela rede
                    }
                }

                m_CanBuilder = false;
                m_NextCooldownTime = Time.time + m_CooldownTime;
            }
		}
	}
}
