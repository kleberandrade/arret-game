using UnityEngine;

public class CameraMoveWithAcell : MonoBehaviour {

    public float m_Speed = 10.0F;

    private void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.x;
        dir.y = -Input.acceleration.y;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * m_Speed);
    }
}
