using UnityEngine;
using UnityEngine.UI;

public class RandomImageUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_sprites;

    private Image m_image;

    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    private void Start()
    {
        Change();
    }

    public void Change()
    {
        if (m_sprites == null)
            return;

        if (m_sprites.Length == 0)
            return;

        int index = Random.Range(0, m_sprites.Length);
        m_image.sprite = m_sprites[index];
    }
}
