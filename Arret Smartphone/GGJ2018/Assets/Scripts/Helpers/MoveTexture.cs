using UnityEngine;

public class MoveTexture : MonoBehaviour
{ 
    public Vector2 m_SpeedAxis = Vector2.one;

    private Renderer m_Renderer;
    
    private void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector2 offset = m_SpeedAxis * Time.time;

        m_Renderer.material.mainTextureOffset = offset;
    }
}
