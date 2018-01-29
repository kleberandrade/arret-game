using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtPoint : MonoBehaviour
{
    public float m_Length = 0.3f;

    public float m_Speed = 0.5f;

    public Vector3 m_Axis = Vector3.up;

    public bool m_CanMove = false;

    private Vector3 m_StartPosition;

    private void Start()
    {
        Move();
    }

    public void Move()
    {
        m_StartPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!m_CanMove)
            return;

        transform.position = m_StartPosition + m_Axis * Mathf.PingPong(Time.time * m_Speed, m_Length);
    }
}
