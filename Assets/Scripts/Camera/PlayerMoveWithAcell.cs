using UnityEngine;

public class PlayerMoveWithAcell : MonoBehaviour {

    public float m_Speed = 10.0F;

    private void Update()
    {
        Vector3 dir = Vector3.zero;
#if UNITY_EDITOR
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
#else
        dir.x = -Input.acceleration.x;
        dir.z = -Input.acceleration.y;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
#endif
        dir *= Time.deltaTime;
        transform.Translate(dir * m_Speed);
    }
}
