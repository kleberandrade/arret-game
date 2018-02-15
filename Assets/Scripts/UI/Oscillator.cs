using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private OscillatorType m_OscillatorType = OscillatorType.Position;
    [SerializeField] private float m_Period = 1.0f;
    [SerializeField] private float m_Amplitude = 0.01f;
    [SerializeField] private Vector3 m_Direction = Vector3.one;
    [SerializeField] private bool m_InitRandomPeriod = false;

    private float m_StartRandomPeriod = 0.0f;
    private Transform m_Transform;
    private Vector3 m_Origin;

    public float Period
    {
        get { return m_Period; }
        set { m_Period = value; }
    }

    public float Amplitude
    {
        get { return m_Amplitude; }
        set { m_Amplitude = value; }
    }

    private void Start()
    {
        m_Transform = transform;

        if (m_InitRandomPeriod)
            m_StartRandomPeriod = Random.Range(0.0f, Mathf.PI);

        switch (m_OscillatorType)
        {
            case OscillatorType.Position:
                m_Origin = m_Transform.position;
                break;

            case OscillatorType.Scale:
                m_Origin = m_Transform.localScale;
                break;

            case OscillatorType.Rotation:
                m_Origin = m_Transform.eulerAngles;
                break;
        }
    }

    private void Update()
    {
        switch (m_OscillatorType)
        {
            case OscillatorType.Position:
                m_Transform.position = m_Origin + m_Direction * Mathf.Sin((m_StartRandomPeriod + Time.time) * m_Period) * m_Amplitude;
                break;

            case OscillatorType.Rotation:
                m_Transform.eulerAngles = m_Origin + m_Direction * Mathf.Sin((m_StartRandomPeriod + Time.time) * m_Period) * m_Amplitude;
                break;

            case OscillatorType.Scale:
                m_Transform.localScale = m_Origin + m_Direction * Mathf.Sin((m_StartRandomPeriod + Time.time) * m_Period) * m_Amplitude;
                break;
        }
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }
}


public enum OscillatorType
{
    Position,
    Rotation,
    Scale
}