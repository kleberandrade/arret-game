using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public int m_Speed;

    public Vector3 m_Axis = Vector3.up;

    public bool m_CanRotate = false;

    private void Update()
    {
        if (!m_CanRotate)
            return;

        transform.RotateAround(transform.position, m_Axis, m_Speed * Time.deltaTime);
    }
}
