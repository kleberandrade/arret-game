using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RayLaser : MonoBehaviour 
{
	public float m_WidthRay = 2.0f;

    [Range(0.0f, 1.0f)]
    public float m_StartAlpha = 0.8f;

    [Range(0.0f, 1.0f)]
	public float m_EndAlpha = 0.5f;

	public float m_MakeLaserTime = 0.3f;

    public float m_ScrollSpeed = 1.0f;

    public float m_SmoothScale = 0.1f;

    private LineRenderer m_LineRenderer;

    private Renderer m_Renderer;

	private Transform m_EndPoint;

    private void Awake()
	{
		m_LineRenderer = GetComponent<LineRenderer> ();
        m_Renderer = GetComponent<Renderer>();
	}

	private void OnEnable()
	{
		BuildManager.OnTowerDestroy += OnTowerDestroy;	
	}

	private void OnDisable()
	{
		BuildManager.OnTowerDestroy -= OnTowerDestroy;	
	}

	private void Start()
	{
		m_LineRenderer.startWidth = m_WidthRay;
		m_LineRenderer.endWidth = m_WidthRay;
    }

	public void SetEndPoint(Transform endPoint, Color color)
	{
		m_EndPoint = endPoint;

        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, transform.position);

        m_LineRenderer.startColor = ColorExtension.AlphaColor(color, m_StartAlpha);
        m_LineRenderer.endColor = ColorExtension.AlphaColor(color, m_EndAlpha);

        Renderer rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", color);
        rend.material.SetColor("_EmissionColor", color);
        rend.material.EnableKeyword("_Emission");

        StartCoroutine (MakeLaser ());
	}

	private IEnumerator MakeLaser()
	{
		float startTime = Time.time;
        Vector3 position = transform.position;
        
        while (Vector3.Distance (position, m_EndPoint.position) >= 0.01f) {
            float elapsedTime = (Time.time - startTime);
            position = Vector3.Lerp (transform.position, m_EndPoint.position, elapsedTime / m_MakeLaserTime);
            m_LineRenderer.SetPosition(1, position);
			yield return null;
		}

        m_LineRenderer.SetPosition(1, m_EndPoint.position);

        AddColliderToLineRenderer();
	}

    private void AddColliderToLineRenderer()
    {
        // Adicionando um Collider para o Laser
        BoxCollider col = new GameObject("LaserCollider").AddComponent<BoxCollider>();
        col.transform.parent = transform;

        // Calculando o ponto médio entre as duas torres
        Vector3 midPoint = (transform.position + m_EndPoint.position) / 2.0f;
        col.transform.position = midPoint;

        // Calculando o comprimento do laser
        float lineLength = Vector3.Distance(transform.position, m_EndPoint.position);
        col.size = new Vector3(lineLength, 1.0f, 0.4f);

        // Calculando o ângulo entre as torres
        Quaternion lookAt = Quaternion.LookRotation(m_EndPoint.position - transform.position);
        col.transform.rotation = lookAt * Quaternion.AngleAxis(90, Vector3.up);
    }

    public void OnTowerDestroy(Vector3 position)
	{
		if (m_EndPoint == null || Vector3.Distance(m_EndPoint.position, position) <= float.Epsilon)
			Destroy (gameObject);
	}

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, m_EndPoint.position);
        float offset = Time.time * (m_ScrollSpeed / distance);

        m_LineRenderer.material.SetTextureScale("_MainTex", new Vector2(m_SmoothScale / distance, 1.0f));
        m_LineRenderer.material.SetTextureOffset("_MainTex", new Vector2(-offset, 0.0f));
    }
}