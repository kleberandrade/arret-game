using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private GameObject m_Target;

    private void Update()
    {
        if (m_Target)
            transform.LookAt(m_Target.transform);
    }

}
